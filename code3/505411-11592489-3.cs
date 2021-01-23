    public static async Task<string> Get(string url, bool proxy) {
    
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
        using (WebResponse resp = await req.GetResponseAsync())
        using (StreamReader SR = new StreamReader(resp.GetResponseStream())) {
            return await SR.ReadToEndAsync();
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
    
        tasks = allSElist.OfType<string>()
                         .Select(url => {
            return Get(url, Settings1.Default.Proxyset)
                    .ContinueWith(htmlContentTask => {
                        // No TaskContinuationOptions, so know always OK here
                        var htmlContent = htmlContentTask.Result;
                        var emails = ExtractEmails(htmlContent);
                        foreach (var email in emails) {
                            // No InvokeAsync on WinForms, so do this the old way.
                            Action dgeins = () => mailDataGrid.Rows.Insert(0, email, url);
                            mailDataGrid.BeginInvoke(dgeins);
                        }
                    });
        });
    
        tasks.WaitAll();
    }
