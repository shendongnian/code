    using (WebClient wc = new WebClient())
    {
        var json = wc.DownloadString("http://search.twitter.com/search.json?&q=felipe&rpp=40");
        dynamic obj = JsonConvert.DeserializeObject(json);
        foreach (var result in obj.results)
        {
            Console.WriteLine("{0} - {1}:\n{2}\n\n", result.from_user_name, 
                                                     (DateTime)result.created_at, 
                                                     result.text);
        }
    }
