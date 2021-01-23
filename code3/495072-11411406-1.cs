    public static class HttpUtil
    {
        public static String GetResponseString(Uri url, CookieContainer cc)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.CookieContainer = cc;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            String responseString = reader.ReadToEnd();
            response.Close();
            return responseString;
        }
        public static String GetResponseString(Uri url, String postData, CookieContainer cc)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Post;
            request.ContentLength = postData.Length;
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cc;
            StreamWriter writer = new StreamWriter(request.GetRequestStream());
            writer.Write(postData);
            writer.Close();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            String responseString = reader.ReadToEnd();
            response.Close();
            return responseString;
        }
    }
