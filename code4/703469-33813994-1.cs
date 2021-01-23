                Google.GData.Client.RequestSettings settings = new RequestSettings("<AppName>");
                Google.GData.Client.OAuth2Parameters parameters = new OAuth2Parameters()
                {
                    ClientId = "<YourClientId>",
                    ClientSecret = "<YourClientSecret>",
                    AccessToken = "<OldAccessToken>", //really necessary?
                    
                    RedirectUri = "urn:ietf:wg:oauth:2.0:oob",
                    RefreshToken = "<YourRefreshToken>",
                    AccessType = "offline",
                    TokenType = "refresh",
                    Scope = "https://www.google.com/m8/feeds/" //Change to needed scopes, I used this for ContactAPI
                };
                try
                {
                    Google.GData.Client.OAuthUtil.RefreshAccessToken(parameters);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
