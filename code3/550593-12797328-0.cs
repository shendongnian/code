    class YouTube
    {
        public void Login()
        {
            HttpWebRequest request = GetNewRequest("https://accounts.google.com/ServiceLoginAuth", cookies);
            request.Referer = "https://accounts.google.com/ServiceLogin?passive=true&continue=https%3A%2F%2Fwww.youtube.com%2Fsignin%3Faction_handle_signin%3Dtrue%26feature%3Dsign_in_button%26nomobiletemp%3D1%26hl%3Den_US%26next%3D%252F&uilel=3&hl=en_US&service=youtube";
            request.Host = "accounts.google.com";
            Dictionary<string, string> parameters = new Dictionary<string, string>{
                {"continue","https%3A%2F%2Fwww.youtube.com%2Fsignin%3Faction_handle_signin%3Dtrue%26feature%3Dsign_in_button%26nomobiletemp%3D1%26hl%3Den_US%26next%3D%252F"},
                {"service","youtube"},{"uilel","3"},{"dsh","157212168103955870"},{"hl","en_US"},
                {"GALX","PTqcwpZb2aE"},{"pstMsg","1"},{"dnConn",""}, {"checkConnection","youtube%3A248%3A1"}, 
                {"checkedDomains","youtube"}, {"timeStmp",""}, {"secTok",""}, {"Email","username"}, {"Passwd","password"}, 
                {"signIn","Sign+in"}, {"PersistentCookie","yes"}, {"rmShown","1"}};
            HttpWebResponse response = MakeRequest(request, cookies, parameters);
            response.Close();
        }
        private static CookieContainer cookies = new CookieContainer();
        private static HttpWebRequest GetNewRequest(string targetUrl, CookieContainer SessionCookieContainer)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(targetUrl);
            request.CookieContainer = SessionCookieContainer;
            request.AllowAutoRedirect = false;
            return request;
        }
        private static HttpWebResponse MakeRequest(HttpWebRequest request, CookieContainer SessionCookieContainer, Dictionary<string, string> parameters = null)
        {
            request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/536.5 (KHTML, like Gecko) Chrome/19.0.1084.52 Safari/536.5Accept: */*";
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            request.CookieContainer = SessionCookieContainer;
            request.AllowAutoRedirect = false;
            
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            string postData = string.Empty;
            foreach (KeyValuePair<String, String> parametro in parameters)
            {
                if (postData.Length == 0)                
                    postData += String.Format("{0}={1}", parametro.Key, parametro.Value);                
                else                
                    postData += String.Format("&{0}={1}", parametro.Key, parametro.Value);                
            }
            byte[] postBuffer = UTF8Encoding.UTF8.GetBytes(postData);
            using (Stream postStream = request.GetRequestStream())
            {
                postStream.Write(postBuffer, 0, postBuffer.Length);
            }
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            SessionCookieContainer.Add(response.Cookies);
            while (response.StatusCode == HttpStatusCode.Found)
            {
                response.Close();
                request = GetNewRequest(response.Headers["Location"], SessionCookieContainer);
                response = (HttpWebResponse)request.GetResponse();
                SessionCookieContainer.Add(response.Cookies);
            }
            return response;
        }
    }
