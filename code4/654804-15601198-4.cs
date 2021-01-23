    public ObservableCollection<string> PlayerCardImages
    {
        get
        {
            var results = new ObservableCollection<string>();
            foreach (var card in PlayerCards)
            {
                results.Add(card.ImageUrl);
            }
            return results;
        }
    }
