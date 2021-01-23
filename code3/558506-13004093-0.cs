    public async void DownloadWebPage(string address)
    {
        using(var webClient = new WebClient())
        {
            var webPageContents = await webClient.DownloadStringTaskAsync();
    
            // Woohoo, we have the contents of the web page. Do anything with it...
            Console.WriteLine(webPageContents);
        }
    }
    
    // Usage:
    DownloadWebPage("http://www.google.com");
