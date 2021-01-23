    if (Settings.Favorites.Value == null)
    {
      Settings.Favorites.Value.Add(favorUrl);  // throws NullReferenceException 
                                               // because Value is null
    }
