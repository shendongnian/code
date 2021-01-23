    foreach (var item in library.Songs)
    {
       System.Diagnostics.Debug.WriteLine(item.Album.ToString());
       System.Diagnostics.Debug.WriteLine(item.Artist.Name);
       System.Diagnostics.Debug.WriteLine(item.Duration);
       System.Diagnostics.Debug.WriteLine(item.Name);
       System.Diagnostics.Debug.WriteLine(item.TrackNumber);
    }
