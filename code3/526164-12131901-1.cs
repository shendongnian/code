    private Task<string> simpleRequest(String url)
    {
        return Task.Factory.StartNew(() =>
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                string result = reader.ReadToEnd();
                stream.Dispose();
                reader.Dispose();
                return result;
            });
    }
