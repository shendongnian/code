    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://stream.twitter.com/1/statuses/sample.json");
    webRequest.Credentials = new NetworkCredential("....", "......");
    webRequest.Timeout = -1;
    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
    StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
    while (true)
    {
        var line = responseStream.ReadLine();
        if (String.IsNullOrEmpty(line)) continue;
        dynamic obj = JsonConvert.DeserializeObject(line);
        if (obj.user != null)
            Console.WriteLine(obj.user.screen_name + ": " + obj.text);
    }
