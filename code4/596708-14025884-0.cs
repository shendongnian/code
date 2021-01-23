        private static string PerformPostRequest(string uri, CookieContainer cookieJar, string parameters)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(uri);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Method = "POST";
            request.CookieContainer = cookieJar;
            byte[] bytes = Encoding.ASCII.GetBytes(parameters);
            Stream os = null;
            request.ContentLength = bytes.Length;  
            os = request.GetRequestStream();
            os.Write(bytes, 0, bytes.Length);
            if (os != null)
            {
                os.Close();
            }
            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(webResponse.GetResponseStream());
            return sr.ReadToEnd().Trim();
        }
