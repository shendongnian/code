    var claimsHelper = new MsOnlineClaimsHelper(sharepointOnlineUrl, username, password);
    var client = new WebClient();
    client.Headers[ "Accept" ] = "/";
    client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
    client.Headers.Add(HttpRequestHeader.Cookie, claimsHelper.CookieContainer.GetCookieHeader(new Uri(sharepointOnlineUrl))  );
    var document = client.DownloadString( documentUrl );
