    using (var wc = new WebClient())
    {
        var json = wc.DownloadString("http://www.viki.com/api/v2/channels.json");
        dynamic dynObj = JsonConvert.DeserializeObject(json);
        foreach (var item in dynObj)
        {
            Console.WriteLine(item.title);
            foreach (var episode in item.episodes)
            {
                Console.WriteLine("\t" + episode.title);
            }
        }
    }
