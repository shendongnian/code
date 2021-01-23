        void Login2(string username, string password)
        {
            string pageSource;
            string formUrl = "https://t-mobile.globysonline.com/cv/scripts/A028/eng/logProc.asp?ntry=0&dbg=";
            string formParams = string.Format("login={0}&sslProt={1}&pwd={2}&gru={3}", username, "", password, "115237091");
            //string cookieHeader;
            CookieContainer cookies = new CookieContainer();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(formUrl);
            req.CookieContainer = cookies;
            req.AllowAutoRedirect = false;
            req.ContentType = "application/x-www-form-urlencoded";
            req.Method = "POST";
            byte[] bytes = System.Text.Encoding.ASCII.GetBytes(formParams);
            req.ContentLength = bytes.Length;
            using (Stream os = req.GetRequestStream())
            {
                os.Write(bytes, 0, bytes.Length);
            }
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            cookies.Add(resp.Cookies);
            //cookieHeader = resp.Headers["Set-cookie"];
            string getUrl = "https://t-mobile.globysonline.com/cv/scripts/A028/eng/home.asp";
            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            getRequest.CookieContainer = cookies; 
            getRequest.Method = "GET";
            getRequest.AllowAutoRedirect = false;
            //getRequest.Headers.Add("Cookie", cookieHeader);
            HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
            cookies.Add(getResponse.Cookies);
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }
            cookies.Add(getResponse.Cookies);
            Response.Redirect(getUrl);
        }
