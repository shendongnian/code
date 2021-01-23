        string redirect = Request.QueryString["redirect"];
        
        string acceptsCookies = null;
        // Was the cookie accepted?
        if (Request.Cookies["TestCookie"] == null)
        {
            // No cookie, so it must not have been accepted
            acceptsCookies = "0";
        }
        else
        {
            acceptsCookies = "1";
            // Delete test cookie
            Response.Cookies["TestCookie"].Expires = DateTime.Now.AddDays(-1);
        }
        redirect = redirect.Replace("AcceptsCookies=", "AcceptsCookies=" + acceptsCookies);
        Response.Redirect(BasePage.ResolveUrl(redirect), true);
    }
