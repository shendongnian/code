    public static Boolean isSiteOnline(String url)
        {
            Boolean result = true;
            HttpWebRequest httpReq = (HttpWebRequest)WebRequest.Create(url);
            httpReq.AllowAutoRedirect = false;
            HttpWebResponse httpRes = (HttpWebResponse)httpReq.GetResponse();
            if (httpRes.StatusCode != HttpStatusCode.OK)
                result = false;
            httpRes.Close();
            return result;
        }
