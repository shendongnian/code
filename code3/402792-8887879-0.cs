    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("https://stream.twitter.com/1/statuses/sample.json");
    webRequest.Credentials = new NetworkCredential("...", "......");
    webRequest.Timeout = -1;
    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
    Encoding encode = Encoding.GetEncoding("utf-8");
    StreamReader responseStream = new StreamReader(webResponse.GetResponseStream());
    string line;
    while (true)
    {
        line = responseStream.ReadLine();
        dynamic obj = JsonUtils.JsonObject.GetDynamicJsonObject(line);
        if(obj.user!=null)
            Console.WriteLine(obj.user.screen_name + " => " + obj.text);
    }
