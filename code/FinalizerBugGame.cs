using Sandbox;
using Sandbox.UI;

namespace FinalizerBug
{
	partial class FinalizerBugGame : GameBase
	{
		public FinalizerBugGame()
		{
			if ( IsServer )
				_ = new FinalizerBugHud();
		}

		public override void Simulate( Client cl )
		{
			if ( Input.Pressed( InputButton.Reload ) )
				_ = new BugHere();
		}

		// Forced to define these :\
		public override CameraSetup BuildCamera( CameraSetup camSetup ) => camSetup;
		public override bool CanHearPlayerVoice( Client source, Client dest ) => true;
		public override void ClientDisconnect( Client cl, NetworkDisconnectionReason reason ) { }
		public override void ClientJoined( Client cl ) { }
		public override void OnVoicePlayed( ulong steamId, float level ) { }
		public override void PostLevelLoaded() { }
		public override void Shutdown() { }
	}

	class BugHere
	{
		~BugHere()
		{
			throw new System.Exception( "Your game will now close" );
		}
	}

	class FinalizerBugHud : HudEntity<RootPanel>
	{
		public FinalizerBugHud()
		{
			if ( !IsClient )
				return;

			RootPanel.SetTemplate( "/hud.html" );
		}
	}
}
