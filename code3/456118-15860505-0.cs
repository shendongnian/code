    public class LiveLogin
        {
            private static readonly string[] Scopes =
                new[]
                    {
                        "wl.signin",
                        "wl.basic",
                        "wl.calendars",
                        "wl.calendars_update",
                        "wl.contacts_calendars",
                        "wl.events_create"
                    };
    
            private LiveAuthClient _authClient;
    
    
    
            public async Task<LiveConnectClient> Login()
            {
                _authClient = new LiveAuthClient("**your client id here**");
    
                LiveLoginResult result = await _authClient.InitializeAsync(Scopes);
                if (result.Status == LiveConnectSessionStatus.Connected)
                {
                    return new LiveConnectClient(result.Session);
                }
                result = await _authClient.LoginAsync(Scopes);
                if (result.Status == LiveConnectSessionStatus.Connected)
                {
                    return new LiveConnectClient(result.Session);
                }
                return null;
            }
    
            
        }
