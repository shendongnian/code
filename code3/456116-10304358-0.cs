    using System.Windows;
    using Microsoft.Live;
    
    public class LiveLogin
    {
    
        private static readonly string[] scopes = 
            new string[] { 
                "wl.signin", 
                "wl.basic", 
                "wl.calendars", 
                "wl.calendars_update", 
                "wl.contacts_calendars", 
                "wl.events_create" };
    
        private LiveAuthClient authClient;
        private LiveConnectClient liveClient;
    
    
        public LiveLogin()
        {
            this.authClient = new LiveAuthClient("**your client id here**");
            this.authClient.InitializeCompleted += authClient_InitializeCompleted;
            this.authClient.InitializeAsync(scopes);
        }
    
        private void authClient_InitializeCompleted(object sender, LoginCompletedEventArgs e)
        {
            if (e.Status == LiveConnectSessionStatus.Connected)
            {
                this.liveClient = new LiveConnectClient(e.Session);
            }
            else
            {
                this.authClient.LoginCompleted += authClient_LoginCompleted;
                this.authClient.LoginAsync(scopes);
            }
        }
    
        private void authClient_LoginCompleted(object sender, LoginCompletedEventArgs e)
        {
            if (e.Status == LiveConnectSessionStatus.Connected)
            {
                this.liveClient = new LiveConnectClient(e.Session);
                MessageBox.Show("Signed");
            }
            else
            {
                MessageBox.Show("Failed!");
            }
        }
    }
