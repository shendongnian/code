        public void Extend(int SessionLimit)
        {
            FormsAuthenticationTicket OriginalTicket = ((FormsIdentity)Context.User.Identity).Ticket;
            FormsAuthenticationTicket NewTicket = new FormsAuthenticationTicket(1, OriginalTicket.Name, DateTime.Now, DateTime.Now.AddMinutes(SessionLimit), false, OriginalTicket.UserData);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(NewTicket));
            authCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(authCookie);
        }
