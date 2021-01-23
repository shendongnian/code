    using System.Windows;
    using Microsoft.Live;
    public class LiveLogin : PhoneApplicationPage
    {
        private static readonly string[] _scopes =
            new[] { 
            "wl.signin", 
            "wl.basic", 
            "wl.calendars", 
            "wl.calendars_update", 
            "wl.contacts_calendars", 
            "wl.events_create" };
        private LiveConnectClient _connection;
        private LiveLoginResult _login;
        public LiveLogin()
        {
            this.Loaded += this.OnLoaded;
        }
        private async void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            //----------------------------------------------------------------------
            // Login to skydrive
            //----------------------------------------------------------------------
            await SkydriveLogin();
        }
        private async Task SkydriveLogin()
        {
            try
            {
                //----------------------------------------------------------------------
                // Initialize our auth client with the client Id for our specific application
                //----------------------------------------------------------------------
                LiveAuthClient authClient = new LiveAuthClient("**your client id here**");
                //----------------------------------------------------------------------
                // Using InitializeAsync we can check to see if we already have an connected session
                //----------------------------------------------------------------------
                _login = await authClient.InitializeAsync(_scopes);
                //----------------------------------------------------------------------
                // If not connected, bring up the login screen on the device
                //----------------------------------------------------------------------
                if (_login.Status != LiveConnectSessionStatus.Connected)
                {
                    _login = await authClient.LoginAsync(_scopes);
                }
                //----------------------------------------------------------------------
                // Initialize our connection client with our login result
                //----------------------------------------------------------------------
                _connection = new LiveConnectClient(_login.Session);
            }
            catch (Exception ex)
            {
                //TODO: Add connection specific exception handling
            }
        }
    }
