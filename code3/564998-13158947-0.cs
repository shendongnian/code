    public static String GetResponseString(Uri url, CookieContainer cc)
    {
        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
        request.Method = WebRequestMethods.Http.Get;
        request.CookieContainer = cc;
        request.AutomaticDecompression = DecompressionMethods.GZip;
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        String responseString = reader.ReadToEnd();
        response.Close();
        return responseString;
    }
