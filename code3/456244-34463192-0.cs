      var googleApiOptions = new GoogleOAuth2AuthenticationOptions()
            {
                AccessType = "offline", // can use only if require
                ClientId = ClientId,
                ClientSecret = ClientSecret,
                Provider = new GoogleOAuth2AuthenticationProvider()
                {
                    OnAuthenticated = context =>
                    {
                        context.Identity.AddClaim(new Claim("Google_AccessToken", context.AccessToken));
                        if (context.RefreshToken != null)
                        {
                            context.Identity.AddClaim(new Claim("GoogleRefreshToken", context.RefreshToken));
                        }
                        context.Identity.AddClaim(new Claim("GoogleUserId", context.Id));
                        context.Identity.AddClaim(new Claim("GoogleTokenIssuedAt", DateTime.Now.ToBinary().ToString()));
                        var expiresInSec = 10000;
                        context.Identity.AddClaim(new Claim("GoogleTokenExpiresIn", expiresInSec.ToString()));
                        
                        return Task.FromResult(0);
                    }
                },
                SignInAsAuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            };
            googleApiOptions.Scope.Add("openid"); // Need to add for google+ 
            googleApiOptions.Scope.Add("profile");// Need to add for google+ 
            googleApiOptions.Scope.Add("email");// Need to add for google+ 
            googleApiOptions.Scope.Add("https://www.googleapis.com/auth/analytics.readonly");
         
            app.UseGoogleAuthentication(googleApiOptions);
