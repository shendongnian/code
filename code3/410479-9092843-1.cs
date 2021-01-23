    void Fetcher_RequestComplete(bool error, string result, int requestsLeft)
    {
     if (!error)
     {
        ModGrid.ItemsSource = Parser.ParseMods(result));
     }
    }
