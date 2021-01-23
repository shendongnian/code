    UriBuilder uriBuilder = new UriBuilder(url);
    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriBuilder.Uri);
    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = bytesToPost.Length;
    using(Stream postStream = request.GetRequestStream())
    {
         postStream.Write(bytesToPost, 0, bytesToPost.Length);
         postStream.Close();
    }
    HttpWebResponse response = (HttpWebResponse )request.GetResponse();
    string url = response.ResponseUri
