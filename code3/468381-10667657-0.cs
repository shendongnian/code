    private string fetchRSS(string url, DateTime lastUpdate){
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.IfModifiedSince = lastUpdate;
        // if the file wasn't modified since the specified time it won't be fetched and an exception will be thrown
        try{
           WebResponse response = request.GetResponse();
           Stream stream = response.GetResponseStream();
           StreamReader reader = new StreamReader(stream);
           return reader.ReadToEnd();
        }
        // this will happen if the fetching of the file failed or the file wasn't updated
        return null;
    }
