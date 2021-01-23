            CookieContainer _yahooContainer;
            string _login = "myyahoologin";
            string _password = "myyahoopassword";
            string strPostData = String.Format("login={0}&passwd={1}", _login, _password);
            // Setup the http request.
            HttpWebRequest wrWebRequest = WebRequest.Create(LoginUrl) as HttpWebRequest;
            wrWebRequest.Method = "POST";
            wrWebRequest.ContentLength = strPostData.Length;
            wrWebRequest.ContentType = "application/x-www-form-urlencoded";
            _yahooContainer = new CookieContainer();
            wrWebRequest.CookieContainer = _yahooContainer;
            // Post to the login form.
            using (StreamWriter swRequestWriter = new StreamWriter(wrWebRequest.GetRequestStream()))
            {
                swRequestWriter.Write(strPostData);
                swRequestWriter.Close();           
            }
            // Get the response.
            HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();
            if (hwrWebResponse.ResponseUri.AbsoluteUri.Contains("my.yahoo.com"))
            {
                // you authenticated properly
            }
            // Now use the cookies to create more requests.
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(_downloadUrl);
            req.CookieContainer = _yahooContainer;
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
