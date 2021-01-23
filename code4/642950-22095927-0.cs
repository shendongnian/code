            fbAuthOpt.Scope.Add("email");
            fbAuthOpt.Scope.Add("user_birthday");
            fbAuthOpt.AppId = "";
            fbAuthOpt.AppSecret = "";
            fbAuthOpt.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            fbAuthOpt.Provider = new FacebookAuthenticationProvider
            {
                OnAuthenticated = async context =>
                {
                    context.Identity.AddClaim(new System.Security.Claims.Claim("FacebookAccessToken", context.AccessToken));
    
                    foreach (var claim in context.User)
                    {
                        var claimType = string.Format("urn:facebook:{0}", claim.Key);
                        var claimValue = claim.Value.ToString();
    
                        if (!context.Identity.HasClaim(claimType, claimValue))
                            context.Identity.AddClaim(new System.Security.Claims.Claim(claimType, claimValue, "XmlSchemaString", "Facebook"));
                    }
    
                }
            };
    
            app.UseFacebookAuthentication(fbAuthOpt);
