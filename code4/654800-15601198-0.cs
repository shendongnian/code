    public ObservableCollection<ImageSource> PlayerCardImages
    {
        get
        {
            var results = new ObservableCollection<ImageSource>();
            foreach (var card in PlayerCards)
            {
                results.Add(new BitmapImage(new Uri(card.ImageUrl)));
            }
            return results;
        }
    }
