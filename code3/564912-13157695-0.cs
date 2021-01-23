             var web = new HtmlWeb();
             web.PreRequest = delegate(HttpWebRequest webRequest)
             {
             webRequest.Timeout = 1200000;
             return true;
             };
             var proxy = new WebProxy() { UseDefaultCredentials = true };
             var doc = web.Load("http://localhost:2120", "GET", proxy, 
             CredentialCache.DefaultNetworkCredentials);
            
            var linksOnPage = from lnks in document.DocumentNode.Descendants()
                              where lnks.Name == "a" &&
                                   lnks.Attributes["href"] != null &&
                                   lnks.InnerText.Trim().Length > 0 
                                   
                              select new
                              {
                                  Url = lnks.Attributes["href"].Value,
                                  Text = lnks.InnerText
                              };
            linksOnPage.All(t => { Console.WriteLine(t.Text + " : " + t.Url); return true; });
