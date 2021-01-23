    var list = new[] 
    { 
        "http://google.com", 
        "http://yahoo.com", 
        "http://stackoverflow.com" 
    }; 
    
    var tasks = Parallel.ForEach(list,
            s =>
            {
                using (var client = new WebClient())
                {
                    Console.WriteLine($"starting to download {s}");
                    string result = client.DownloadString((string)s);
                    Console.WriteLine($"finished downloading {s}");
                }
            });
