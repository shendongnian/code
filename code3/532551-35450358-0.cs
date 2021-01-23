    using (var library = new MediaLibrary())
    {
       var appFolder = library.RootPictureAlbum.Albums.FirstOrDefault(al => al.Name == "folderName");
        if (appFolder != null && appFolder.Pictures.Count > 0)
        {
            var file = appFolder.Pictures.FirstOrDefault(pc => pc.Name == ("fileName"));
            if (file == null)
            {
                // file doesn't exist
            }
            else
            {
                // file does exist
            }
        }
    }
