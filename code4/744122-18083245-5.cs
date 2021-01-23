        if (rememberMe)
        {
            // Clear any other tickets that are already in the response
            Response.Cookies.Clear(); 
            // Set the new expiry date - to thirty days from now
            DateTime expiryDate = DateTime.Now.AddDays(30);
            // Create a new forms auth ticket
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, loginModel.UserName,  DateTime.Now, expiryDate, true, String.Empty);
            // Encrypt the ticket
            string encryptedTicket = FormsAuthentication.Encrypt(ticket);
            // Create a new authentication cookie - and set its expiration date
            HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            authenticationCookie.Expires = ticket.Expiration;
            // Add the cookie to the response.
            Response.Cookies.Add(authenticationCookie);
        }
