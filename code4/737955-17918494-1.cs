    using(WebClient webClient = new WebClient())
    {
        using(Stream stream = webClient.OpenRead(uriString))
        {
            using( StreamReader sr = new StreamReader(stream) )
            {
                Console.WriteLine(sr.ReadToEnd());
            }
        }
    }
