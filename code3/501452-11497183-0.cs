    void Download(GameType type, Action onCompletion)
    {
        WebClient client = new WebClient();
        client.DownloadProgressChanged += (s, args) =>
        {
            // Handle change in progress.
        };
    
        client.DownloadStringCompleted += (s, args) =>
        {
            XDocument feed = XDocument.Parse(args.Result);
    
            var itemSource = from query in feed.Root
                                          select new NewGamesClass
                                          {
                                              NewGameTitle = (string)query.Element("Title"),
                                              NewGameDescription = (string)query.Element("Descript
                                              NewGameImage = (string)query.Element("Image")
                                          };
            switch (type)
            {
                case GameType.ComingSoon:
                    {
                        ComingSoonList.ItemSource = itemSource;
                    }
                case GameType.NewGames:
                    {
                        NewGameList.ItemSource = itemSource;
                    }
    
            }
    
            if (onCompletion != null)
                onCompletion();
        };
    
        switch (type)
        {
            case GameType.NewGames:
                {
                    client.DownloadStringAsync(new Uri("http://microsoft.com", UriKind.Absolute));
                    break;
                }
            case GameType.ComingSoon:
                {
                    client.DownloadStringAsync(new Uri("http://www.bing.com", UriKind.Absolute));
                    break;
                }
        }
    }
