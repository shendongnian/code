    static class Requester
    {
        static CookieContainer cookieJar = new CookieContainer();
        static string userAgent = ""; //specify your user agent
        /// <summary>
        /// Static method to request a web page. 
        /// It acts like a browser which means that keeps all cookies for depending domain.
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        static public FinalResponse sendRequest(string URL)
        {
            return sendRequest(URL, "");
        }
        static public FinalResponse sendRequest(string URL, string parameters)
        {
            FinalResponse result = new FinalResponse();
            Stopwatch timer = new Stopwatch();
            HttpWebRequest request;
            try
            {
                request = (HttpWebRequest)HttpWebRequest.Create(URL);
                request.Referer = "http://google.com"; //specify your referer
                request.CookieContainer = cookieJar;
                request.UserAgent = userAgent;
                BugFix_CookieDomain();
                request.AllowAutoRedirect = true;
                if (parameters != "")
                {
                    request.Method = "POST";
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.ContentLength = parameters.Length;
                    //push parameters to request stream
                    StreamWriter myWriter = new StreamWriter(request.GetRequestStream());
                    myWriter.Write(parameters);
                    myWriter.Close();
                }
                //send request
                result.requestTime = DateTime.Now;
                timer.Start();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                timer.Stop();
                result.responseMilliseconds = timer.ElapsedMilliseconds;
                BugFix_CookieDomain();
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result.document = sr.ReadToEnd();
                    sr.Close();
                    result.isSucceded = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result.document = "";
                result.isSucceded = false;
            }
            return result;
        }
        /// <summary>
        /// Call this function before all usage of cookieJar. 
        /// It fixes the bug (!) of CookieContainer Class. 
        /// </summary>
        private static void BugFix_CookieDomain()
        {
            System.Type _ContainerType = typeof(CookieContainer);
            Hashtable table = (Hashtable)_ContainerType.InvokeMember("m_domainTable",
                                       System.Reflection.BindingFlags.NonPublic |
                                       System.Reflection.BindingFlags.GetField |
                                       System.Reflection.BindingFlags.Instance,
                                       null,
                                       cookieJar,
                                       new object[] { });
            ArrayList keys = new ArrayList(table.Keys);
            foreach (string keyObj in keys)
            {
                string key = (keyObj as string);
                if (key[0] == '.')
                {
                    string newKey = key.Remove(0, 1);
                    table[newKey] = table[keyObj];
                }
            }
        }
