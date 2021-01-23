    public ActionResult LogOff()
        {
            WebSecurity.Logout();
                     
            string token = Session["facebooktoken"].ToString();
           
            if (token != null)
            {
                var fb = new Facebook.FacebookClient();
                var logoutUrl = fb.GetLogoutUrl(new { access_token = token, next = "http://localhost:58663/" });              
                Response.Redirect(logoutUrl.AbsoluteUri);                                     
            }
            Session.RemoveAll(); 
            return RedirectToAction("Index", "Home");
        }
