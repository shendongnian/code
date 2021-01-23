    ProviderParseResults results = OAuthWebSecurity.TryDeserializeProviderUserId(loginData); 
    if (results == null){
                Response.Redirect("~/Account/Manage");
                return;
            }
    string provider = results.Provider;
    string providerUserId = results.ProviderUserId;
