    public string HttpGet(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    
        try {
            using (Stream stream = response.GetResponseStream()) {
                StreamReader reader = new StreamReader(stream);
    
                return reader.ReadToEnd();
            }
        } finally {
            response.Close();
        }
    }
