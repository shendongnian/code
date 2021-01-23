        void Login2(string username, string password)
        {
            string pageSource;
            string formUrl = "https://server/cv/scripts/A028/eng/logProc.asp?ntry=0&dbg=";
            string formParams = string.Format("login={0}&sslProt={1}&pwd={2}&gru={3}", username, "", password, "115237091");
            // [HK] create a container for the cookies, where they are added automatically
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
            // [HK] no need to add cookies "by hand", that will happen automatically
            //cookies.Add(resp.Cookies);
            string getUrl = "https://server/cv/scripts/A028/eng/home.asp";
            HttpWebRequest getRequest = (HttpWebRequest)WebRequest.Create(getUrl);
            // [HK] use the same cookiecontainer as on the first request - correct
            getRequest.CookieContainer = cookies; 
            getRequest.Method = "GET";
            getRequest.AllowAutoRedirect = false;
            HttpWebResponse getResponse = (HttpWebResponse)getRequest.GetResponse();
            // [HK] no need to add cookies, they should be there already
            //cookies.Add(getResponse.Cookies);
            using (StreamReader sr = new StreamReader(getResponse.GetResponseStream()))
            {
                pageSource = sr.ReadToEnd();
            }
            // [HK] no need to add cookies, they should be there already
            // cookies.Add(getResponse.Cookies);
            Response.Redirect(getUrl);
        }
