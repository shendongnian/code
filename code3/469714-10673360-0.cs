    using (WebClient webClient = new WebClient())
    {
        string url = "http://api.twitter.com/1/statuses/public_timeline.json";
        dynamic json = JsonConvert.DeserializeObject(webClient.DownloadString(url));
        foreach (var item in json)
        {
            Console.WriteLine("{0} {1}", item.user.id, item.user.screen_name);
        }
    }
