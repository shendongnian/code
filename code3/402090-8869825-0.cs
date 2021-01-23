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
                    Console.WriteLine("starting to download {0}", s);
                    string result = client.DownloadString((string)s);
                    Console.WriteLine("finished downloading {0}", s);
                }
            });
