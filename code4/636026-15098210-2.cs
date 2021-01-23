    public static void Get(string uri, string acceptHeader, Action<string> callback)
    {
        var request = (HttpWebRequest)WebRequest.Create(uri);
        request.Accept = acceptHeader;        
        request.BeginGetResponse(o =>
        {
            try
            {
                var response = request.EndGetResponse(o);
                using (var sr = new StreamReader(response.GetResponseStream()))
                {
                    callback(sr.ReadToEnd());
                }
            }
            catch (Exception ex)
            {
                throw new WebException(string.Format("Unable to access {0}", uri), ex);
            }
        }, null);
    }
