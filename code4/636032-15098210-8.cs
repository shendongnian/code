    public async static void Get(string uri, string acceptHeader, Action<string> callback)
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.Accept = acceptHeader;        
        var response = await Task.Factory.FromAsync(
                                 request.BeginGetRequestStream ,
                                 request.EndGetRequestStream ,
                                 uri,
                                 null);
        using (var sr = new StreamReader(response))
        {
            callback(sr.ReadToEnd());
        }
    }
