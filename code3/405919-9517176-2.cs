        //
        // Add project name as UserData to the authentication ticket.
        // This is especially important regarding the "Remembe Me" cookie - when the authentication
        // is remembered we need to know the project and user name, otherwise we end up trying to 
        // use the default project instead of the one the user actually logged on to.
        //
        // http://msdn.microsoft.com/en-us/library/kybcs83h.aspx
        // http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.login.remembermeset(v=vs.100).aspx
        // http://www.hanselman.com/blog/AccessingTheASPNETFormsAuthenticationTimeoutValue.aspx
        // http://www.csharpaspnetarticles.com/2009/02/formsauthentication-ticket-roles-aspnet.html
        // http://www.hanselman.com/blog/HowToGetCookielessFormsAuthenticationToWorkWithSelfissuedFormsAuthenticationTicketsAndCustomUserData.aspx
        // http://stackoverflow.com/questions/262636/cant-set-formsauthenicationticket-userdata-in-cookieless-mode
        //
        protected void LoginUser_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string userName = LoginUser.UserName;
            string password = LoginUser.Password;
            bool rememberMe = LoginUser.RememberMeSet;
            if ( [ValidateUser(userName, password)] )
            {
                // Create the Forms Authentication Ticket
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(
                    1,
                    userName,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes),
                    rememberMe,
                    [ ProjectName ],
                    FormsAuthentication.FormsCookiePath);
                // Create the encrypted cookie
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                if (rememberMe)
                    cookie.Expires = DateTime.Now.AddMinutes(FormsAuthentication.Timeout.TotalMinutes);
                // Add the cookie to user browser
                Response.Cookies.Set(cookie);
                // Redirect back to original URL 
                // Note: the parameters to GetRedirectUrl are ignored/irrelevant
                Response.Redirect(FormsAuthentication.GetRedirectUrl(userName, rememberMe));
            }
        }
 
