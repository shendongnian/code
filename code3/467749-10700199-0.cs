    string uri = "http://...";
    string parameters = String.Format("param1={0}&param2={1}",
                                      HttpUtility.UrlEncode(param1),
                                      HttpUtility.UrlEncode(param2));
    HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(uri);
    webRequest.ContentType = "application/x-www-form-urlencoded";
    webRequest.Method = "POST";
    webRequest.AllowAutoRedirect = true;
    webRequest.MaximumAutomaticRedirections = 1;
    byte[] bytes = Encoding.ASCII.GetBytes(parameters);
    Stream os = null;
    try {
        webRequest.ContentLength = bytes.Length;
        os = webRequest.GetRequestStream();
        os.Write(bytes, 0, bytes.Length);
    } catch (Exception ex) {
        // Handle exception
    } finally {
        if (os != null) {
            os.Close();
        }
    }
