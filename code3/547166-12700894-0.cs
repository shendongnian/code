    var provider = new WebServerClient(GoogleAuthenticationServer.Description)
                               {
                                   ClientIdentifier = _appId,
                                   ClientSecret = _appSecret
                               };
            var auth = new OAuth2Authenticator<WebServerClient>(provider, x => new AuthorizationState { AccessToken = token });
            var analyticsService = new AnalyticsService(auth);
            var accounts = analyticsService.Management.Accounts.List().Fetch();
            var result = new List<Profile>();
            foreach (var account in accounts.Items)
            {
                var webProperties = analyticsService.Management.Webproperties.List(account.Id).Fetch();
                foreach (var webProperty in webProperties.Items)
                {
                    var profiles = analyticsService.Management.Profiles.List(account.Id, webProperty.Id).Fetch();
                    if (profiles.Items != null && profiles.Items.Any())
                    {
                        // these are the ones we want
                        result.AddRange(profiles.Items);
                    }
                }
            }
        }
