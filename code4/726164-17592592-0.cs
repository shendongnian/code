    FormsAuthentication.SignOut();
    HttpCookie c = Request.Cookies[FormsAuthentication.FormsCookieName];
    c.Expires = DateTime.Now.AddDays(-1);
    
    // Update the amended cookie!
    Response.Cookies.Set(c)
    Session.Clear();
    /* Get rid of this, it will break the above by clearing
     * the cookie collection that you've just updated. */
    // Request.Cookies.Clear();
    // Response.Cookies.Clear();
