    using (MediaLibrary library = new MediaLibrary())
    {
        foreach (Album item in library.Albums)
        {
            lstAlbum.Add(item.Songs);
        }
     }
