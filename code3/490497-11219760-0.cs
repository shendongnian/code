        public async Task<bool> Logout()
        {
            // Check to see if the user can sign out (Live account or Local account)
            var onlineIdAuthenticator = new OnlineIdAuthenticator();
            var serviceTicketRequest = new OnlineIdServiceTicketRequest("wl.basic", "DELEGATION");
            await onlineIdAuthenticator.AuthenticateUserAsync(serviceTicketRequest);
            if (onlineIdAuthenticator.CanSignOut)
            {
                LiveAuthClient.Logout();               
            }
             
            return true;
        }
