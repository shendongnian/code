    using (var client = new CookieAwareWebClient())
    {
        var values = new NameValueCollection
        {
            { "username", "john" },
            { "password", "secret" },
        };
        client.UploadValues("http://domain.loc/logon.aspx", values);
        // If the previous call succeeded we now have a valid authentication cookie
        // so we could download the protected page
        string result = client.DownloadString("http://domain.loc/testpage.aspx");
    }
