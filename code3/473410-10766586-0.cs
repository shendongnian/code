    public Task<string> GetAsync(string url)
    {
        var tcs = new TaskCompletionSource<bool>();
        var request = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            request.BeginGetResponse(iar =>
            {
                HttpWebResponse response = null;
                try
                {
                    response = (HttpWebResponse)request.EndGetResponse(iar);
                    using(var reader = new StreamReader(response.GetResponseStream()))
                    {
                        tcs.SetResult(reader.ReadToEnd());
                    }                    
                }
                catch(Exception exc) { tcs.SetException(exc); }
                finally { if (response != null) response.Close(); }
            }, null);
        }
        catch(Exception exc) { tcs.SetException(exc); }
        return tsc.Task; 
    }
