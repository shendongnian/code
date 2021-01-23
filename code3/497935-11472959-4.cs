                // generate the authorization url
                string url = OAuthUtil.CreateOAuth2AuthorizationUrl(parameters);
                // now use the url to authorize the app in the browser and get the access code
                (...)
                // get this information from Google's API Console after registering your app
                var parameters = new OAuth2Parameters
                {
                    ClientId = @"",
                    ClientSecret = @"",
                    RedirectUri = @"",
                    Scope = @"https://www.google.com/m8/feeds/",
                    AccessCode = @"<from previous step>",
                };
                // get an access token
                OAuthUtil.GetAccessToken(parameters);
                // setup connection to contacts service
                var contacts = new ContactsRequest(new RequestSettings("<appname>", parameters));
                // get each contact
                foreach (var contact in contacts.GetContacts().Entries)
                {
                    System.Diagnostics.Debug.WriteLine(contact.ContactEntry.Name.FullName);
                }
