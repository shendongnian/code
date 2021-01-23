    public static string SendGETRequest(string url, string agent, CookieContainer cookieContainer)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = agent;
            request.Method = "GET";
            request.ContentType = "text/html";
            request.CookieContainer = cookieContainer;
            string result;
            using (var myResponse = (HttpWebResponse) request.GetResponse())
            {
                using (var stream = myResponse.GetResponseStream())
                {
                    result = null;
                    if (stream != null)
                    {
                        using (var sr = new StreamReader(stream, System.Text.Encoding.UTF8))
                        {
                            result = sr.ReadToEnd();
                            sr.Close();
                        }
                        stream.Close();
                    }
                }
                myResponse.Close();
            }
            return result;
        }
