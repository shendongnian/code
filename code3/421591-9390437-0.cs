        protected void RequestLogin()
        {
            string OriginalUrl =  HttpContext.Current.Request.RawUrl;
            string LoginPageUrl = "~/LogIn.aspx";
            HttpContext.Current.Response.Redirect(String.Format("{0}?ReturnUrl={1}", 
            LoginPageUrl, OriginalUrl));
        }
