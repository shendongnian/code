     public class HttpConnection
        {
            public static string GetString(string url)
            {
                return GetString(url, Encoding.UTF8);
            }
    
            public static string GetString(string url, Encoding encode)
            {
                HttpWebRequest oReq = (HttpWebRequest)WebRequest.Create(url);
                oReq.UserAgent = @"Mozilla/5.0 (Windows; U; Windows NT 6.1; en-US; rv:1.9.1.5) Gecko/20091102 Firefox/3.5.5";
                oReq.Method = "GET";
                ASCIIEncoding encoding = new ASCIIEncoding();
                HttpWebResponse resp = (HttpWebResponse)oReq.GetResponse();
                StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), encode);
                String s = loResponseStream.ReadToEnd();
                loResponseStream.Close();
    
                return s.Replace("&nbsp;", " ");
            }
    }
