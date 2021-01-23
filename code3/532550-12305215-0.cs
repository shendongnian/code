    using (var ml = new MediaLibrary())
    {
        using (var pics = ml.SavedPictures)
        {
            using (var img = pics.LastOrDefault(pic => pic.Name == FILENAME))
            {
                if (img == null)
                {
                    // file doesn't exist
                }
                else
                {
                    // file does exist
                }
            }
        }
    }
