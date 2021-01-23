    private static string GetTemplate(string queryparams)
    {
        WebRequest request = HttpWebRequest.Create(uri);
        request.Method = WebRequestMethods.Http.Get;
        using(var response = request.GetResponse())
        using(var reader = new StreamReader(response.GetResponseStream())
           string tmp = reader.ReadToEnd();
    }
