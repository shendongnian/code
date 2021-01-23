     string response = requestData("https://api.twitter.com/1/trends/daily.json");
     JObject jsonResponse = new JObject();
     var name = string.Empty;
     var query = string.Empty;
     try
     {
           jsonResponse = JObject.Parse(response);
           name = (string)jsonResponse["name"];
           query = (string)jsonRespone["query"];
     }
     catch
     {
           return "";
     }
       
    public string requestData(string url)
    {
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(resp.GetResponseStream());
        string results = sr.ReadToEnd();
        sr.Close();
        return results;
    } 
         
