     private class CWebClient : WebClient
        {
            public CWebClient()
                : this(new CookieContainer())
            { }
            public CWebClient(CookieContainer c)
            {
                this.CookieContainer = c;
            }
            public CookieContainer CookieContainer { get; set; }
            protected override WebRequest GetWebRequest(Uri address)
            {
                WebRequest request = base.GetWebRequest(address);
                if (request is HttpWebRequest)
                {
                    (request as HttpWebRequest).CookieContainer = this.CookieContainer;
                }
                return request;
            }
        }
        static void Main(string[] args)
        {
            var client = new CWebClient();
            client.BaseAddress = @"http://forum.tractor-italia.net/";
            var loginData = new NameValueCollection();
            loginData.Add("username", "demodemo");
            loginData.Add("password", "demodemo");
            loginData.Add("login","Login");
            loginData.Add("redirect", "download/myfile.php?id=1622");
            client.UploadValues("ucp.php?mode=login", null, loginData);
            
            string remoteUri = "http://forum.tractor-italia.net/download/myfile.php?id=1622";
            client.OpenRead(remoteUri);
            string fileName = String.Empty;
            string contentDisposition = client.ResponseHeaders["content-disposition"];
            if (!string.IsNullOrEmpty(contentDisposition))
        {
            string lookFor = @"=";
            int index = contentDisposition.IndexOf(lookFor, 0);
            if (index >= 0)
                fileName = contentDisposition.Substring(index + lookFor.Length+7);
        }//attachment; filename*=UTF-8''JohnDeere6800.zip
           
           client.DownloadFile(remoteUri, fileName);
            
            
        }
