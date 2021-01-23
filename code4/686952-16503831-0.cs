     public MvcApplication()
        {
            this.AuthorizeRequest += MvcApplication_AuthorizeRequest;
        }
        void MvcApplication_AuthorizeRequest(object sender, EventArgs e)
        {
            FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket("test", true, 30);
            FormsIdentity id = new FormsIdentity(authTicket);
            GenericPrincipal principal = new GenericPrincipal(id, new string[] { });
            HttpContext.Current.User = principal;
        }
