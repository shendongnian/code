    private static bool VBulletinLogin(Uri loginUrl, string user, string password)
    {
        var postParams = new[] {
            new HttpParam("vb_login_username", user),
            new HttpParam("cookieuser", "1"),
            new HttpParam("vb_login_password", password),
            new HttpParam("securitytoken", "guest"),
            new HttpParam("do", "login"),
        };
    
        var http = new HttpContext();
        var src = http.GetEncodedPageData(loginUrl, HttpRequestType.POST, postParams);
        return src.ResponseData.Contains("Thank you for logging in");
    }
