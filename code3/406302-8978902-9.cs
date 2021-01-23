        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity.IsAuthenticated && HttpContext.Current.User.Identity is System.Web.Security.FormsIdentity)
            {
                HttpContext.Current.User = new CAA.Utility.Security.UserPrincipal(HttpContext.Current.User.Identity is CAA.Utility.Security.UserIdentity?  HttpContext.Current.User.Identity as CAA.Utility.Security.UserIdentity : new Utility.Security.UserIdentity(((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket));                
            }
        }
