    protected void Login1_OnLoggedIn(object sender, EventArgs e)
    {
        CheckBox Remember = (CheckBox)((Login)sender).FindControl("Remember");
        if (Remember.Checked)
        {
            FormsAuthenticationTicket t = new FormsAuthenticationTicket(2, Login1.UserName, DateTime.Now, DateTime.Now.AddYears(5), true, "");
            string data = FormsAuthentication.Encrypt(t);
            HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, data);
            authCookie.HttpOnly = true;
            authCookie.Domain = "";
            authCookie.Expires = t.Expiration;
            Response.Cookies.Remove("FORMAUTH");
            Response.Cookies.Add(authCookie);
            Response.Redirect(Request.QueryString["ReturnUrl"]);
        }
    }
