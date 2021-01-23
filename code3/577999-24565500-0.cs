        using (var webClient = new SmartWebClient())
        {
            htmlDictionary.TryAdd(url, webClient.DownloadString(url));
        }
    }
