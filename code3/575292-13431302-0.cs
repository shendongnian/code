    // Use Cookie aware class, this class can be found in my WebScrapper Solution
    CookieWebClient cwc = new CookieWebClient;
    string page = cwc.DownloadString("http://YourUrl.com"); // Cookie is set to the key
    
    // Filter the key
    string search = "name=\"lt\" value=\"";
    int start  = page.IndexOf(search);
    int end = page.IndexOf("\"", start);
    string key = page.Substring(start + search.Length, end-start-search.Length);
    
    // Use special method in CookieWebClient to post data since .NET implementation has some issues.
    // CookieWebClient is the class I wrote found in WebScrapper solution you can download from my site
    // Re use the cookie that is set to the key
    string afterloginpage = cwc.PostPage("http://YourUrl.com", string.Format("username={0}&password={1}&lt={2}&_eventId=submit&credentialsType=ldap", userid, password, key));
    
    // DONE
