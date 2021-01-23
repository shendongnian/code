    foreach (var item in library.Albums)
    { 
       System.Diagnostics.Debug.WriteLine("Album ="+ item.Name);
       System.Diagnostics.Debug.WriteLine("Artist = "+item.Artist.Name);
       System.Diagnostics.Debug.WriteLine("TotalSongs ="+ item.Songs.Count);
    }
