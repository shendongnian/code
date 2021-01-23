    if (Settings.Favorites.Value == null)
    {
      Settings.Favorites.Value = new ObservableCollection<string>();
    }
    Settings.Favorites.Value.Add(favorUrl);
