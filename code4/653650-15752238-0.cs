    protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            FormsAuthenticationTicket ticket = TryDecryptCookie(cookie);
            if (ticket == null)
            {
                return;
            }
            FormsAuthenticationTicket newTicket = ticket;
            if (FormsAuthentication.SlidingExpiration)
            {
                newTicket = FormsAuthentication.RenewTicketIfOld(ticket);
            }
            var identity = new AppIdentity(newTicket);
            var principal = new GenericPrincipal(identity, identity.Roles);
            Context.User = principal;
        }
