    private Uri currentUri;
    
            private void Form1_Load(object sender, EventArgs e)
            {
                currentUri = new Uri(@"http://www.stackoverflow.com");
                HttpWebRequest myRequest = (HttpWebRequest) HttpWebRequest.Create("http://www.stackoverflow.com");
                //WebProxy myProxy = new WebProxy("208.52.92.160:80");
                //myRequest.Proxy = myProxy;
    
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
    
                webBrowser1.DocumentStream = myResponse.GetResponseStream();
    
                webBrowser1.Navigating += new WebBrowserNavigatingEventHandler(webBrowser1_Navigating);
            }
    
            void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
            {
                if (e.Url.AbsolutePath != "blank")
                {
                    currentUri = new Uri(currentUri, e.Url.AbsolutePath);
                    HttpWebRequest myRequest = (HttpWebRequest)HttpWebRequest.Create(currentUri);
    
                    HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
    
                    webBrowser1.DocumentStream = myResponse.GetResponseStream();
                    e.Cancel = true;
                }
            }
