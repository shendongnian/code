    using (WebClient client = new WebClient())
    {
        client.Headers[HttpRequestHeader.Cookie] = 
            System.Web.HttpContext.Current.Request.Headers["Cookie"];
        string htmlCode = client.DownloadString("http://aksphases:200/lynliste.aspx");  
    }
