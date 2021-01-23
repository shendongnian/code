        public bool IsLoggedIn()
        {
        if (System.Web.HttpContext.Current.Session["customer_ref"] != null)
        {
            // The user is logged in
            logged_in = true;
        }
        }
