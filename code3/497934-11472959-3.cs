            // get this information from Google's API Console after registering your app
            var parameters = new OAuth2Parameters
            {
                ClientId = @"",
                ClientSecret = @"",
                RedirectUri = @"",
                Scope = @"https://www.google.com/m8/feeds/",
                AccessCode = "",
                AccessToken = "",  /* use the value returned from the old call to GetAccessToken here */
                RefreshToken = "", /* use the value returned from the old call to GetAccessToken here */
            };
            // get an access token
            OAuthUtil.RefreshAccessToken(parameters);
            // setup connection to contacts service
            var contacts = new ContactsRequest(new RequestSettings("<appname>", parameters));
            // get each contact
            foreach (var contact in contacts.GetContacts().Entries)
            {
                System.Diagnostics.Debug.WriteLine(contact.ContactEntry.Name.FullName);
            }
