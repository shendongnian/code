    string GetPageSource (string url)
    {
    HttpWebRequest webrequest = (HttpWebRequest)WebRequest.Create(url);
    webrequest.Method = "GET";
    HttpWebResponse webResponse = (HttpWebResponse)webrequest.GetResponse();
    string responseHtml;
    using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream()))
    {
        responseHtml = responseStream.ReadToEnd().Trim();
    }
    
    return responseHtml;
    }
