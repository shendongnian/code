    private void SetANewRequestVerificationTokenManuallyInCookieAndOnTheForm()
    {
        if (Response == null)
            return;
                
        string cookieToken, formToken;
        AntiForgery.GetTokens(null, out cookieToken, out formToken); 
        SetCookie("__RequestVerificationToken", cookieToken);
        ViewBag.FormToken = formToken;
    }
    
    private void SetCookie(string name, string value)
    {
       if (Response.Cookies.AllKeys.Contains(name))
           Response.Cookies[name].Value = value;
       else
           Response.Cookies.Add(new HttpCookie(name, value));
    }
