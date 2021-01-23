    public class BackgroundProcess : IRegisteredObject
    {
        private Timer TaskTimer;
        private IHubContext ClientHub;
        public BackgroundProcess()
        {
            HostingEnvironment.RegisterObject( this );
            ClientHub = GlobalHost.ConnectionManager.GetHubContext<webClientHub>();
            TaskTimer = new Timer( OnTimerElapsed, null, TimeSpan.FromSeconds( 0 ), TimeSpan.FromSeconds( 10 ) );
        }
        private void OnTimerElapsed( object sender )
        {
            if (...) //HasAnyClientsConnected, not sure what this would be, I had other criteria
            {
                ClientHub.Clients.All.ping(); //Do your own ping
            }
        }
        public void Stop( bool immediate )
        {
            TaskTimer.Dispose();
            HostingEnvironment.UnregisterObject( this );
        }
