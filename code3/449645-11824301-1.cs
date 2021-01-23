    string CreateHTTGetRequest(string url, string cookie)
    {
        WebRequest request = WebRequest.Create(url);
        request.Method = "GET";
        request.Headers.Add("Cookie", cookie);
        WebResponse response = request.GetResponse();
        Stream stream = response.GetResponseStream();
        StreamReader reader = new StreamReader(stream);
        string content = reader.ReadToEnd();
        reader.Close();
        response.Close();
        return content;
    }
