    public static string Get(string url, bool proxy) {
    
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        if (proxy) {
            req.Proxy = new WebProxy(proxyIP + ":" + proxyPort);
        }
        req.Method = "GET";
        req.UserAgent = Settings1.Default.UserAgent;
        if (Settings1.Default.EnableCookies == true) {
            CookieContainer cont = new CookieContainer();
            req.CookieContainer = cont;
        }
        using (WebResponse resp = req.GetResponse())
        using (StreamReader SR = new StreamReader(resp.GetResponseStream())) {
            return SR.ReadToEnd();
        }
    
    }
    
    private static Regex emailMatcher = new Regex(@"(\b[a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}\b)", RegexOptions.Singleline);
    
    private static string[] ExtractEmails(string htmlContent) {    
            
        return emailMatcher.Matches(htmlContent).OfType<Match>
                           .Select(m => m.Groups[1].Value)
                           .Distinct()
                           .ToArray();
     }
    
    private void SEbgWorker_DoWork(object sender, DoWorkEventArgs e) {
    
        Parallel.ForEach(allSElist.OfType<string>(), url => {
            var htmlContent = Get(url, Settings1.Default.Proxyset);
            var emails = ExtractEmails(htmlContent);
    
            foreach (var email in emails) {
                Action dgeins = () => mailDataGrid.Rows.Insert(0, email, url);
                mailDataGrid.BeginInvoke(dgeins);
            }
    }
