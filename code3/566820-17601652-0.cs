        private static LiveConnectSession _session;
        private static readonly string[] scopes = new[] {"wl.signin", "wl.offline_access", "wl.basic"};
        private async System.Threading.Tasks.Task Authenticate()
        {
            try
            {
                var liveIdClient = new LiveAuthClient("YOUR_CLIENT_ID");
                var initResult = await liveIdClient.InitializeAsync(scopes);
                _session = initResult.Session;
                if (null != _session)
                {
                    await MobileService.LoginWithMicrosoftAccountAsync(_session.AuthenticationToken);
                }
                
                if (null == _session)
                {
                    LiveLoginResult result = await liveIdClient.LoginAsync(scopes);
             
                    if (result.Status == LiveConnectSessionStatus.Connected)
                    {
                        _session = result.Session;
                        await MobileService.LoginWithMicrosoftAccountAsync(result.Session.AuthenticationToken);
                    }
                    else
                    {
                        _session = null;
                        MessageBox.Show("Unable to authenticate with Windows Live.", "Login failed :(", MessageBoxButton.OK);
                    }
                }
            }
            finally
            {
            }
        }
