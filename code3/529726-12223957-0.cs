    using (var wc = new WebClient())
    {
        string json = await wc.DownloadStringTaskAsync(trendingURL);
        dynamic obj = JsonConvert.DeserializeObject(json);
        foreach (var item in obj)
        {
            Console.WriteLine("{0} - {1} - {2} - {3}", 
                        item.title, 
                        item.year, 
                        item.images.poster, 
                        item.ratings.votes);
        }
    }
