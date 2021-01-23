    string fileName = @"Shared\ShellContent\backgroundTileImage.jpg";
    if(TrySaveImage(fileName, "http://foo.com/bar.png"))
    {
        Uri uri = new Uri("isostore:/" + fileName, UriKind.Absolute);
        // Create the tile if we didn't find it already exists.
        var tileData = new StandardTileData
        {
            Title = "My Tile",
            BackgroundImage = uri,
        };
    }
    
    ...
    private bool TrySaveImage(string fileName, string url)
    {
        using (var store = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication())
        {
            try
            {
                var backImage = new Image();
                backImage.Height = backImage.Width = 173;
                backImage.Stretch = Stretch.None;
                backImage.Source = new BitmapImage(new Uri(url));
                backImage.Measure(new Size(173, 173));
                backImage.Arrange(new Rect(0, 0, 173, 173));
                var image = new WriteableBitmap(backImage, null);
                string directory = Path.GetDirectoryName(fileName);
                if (!store.DirectoryExists(directory))
                {
                    store.CreateDirectory(directory);
                }
                using (var stream = store.OpenFile(fileName, FileMode.OpenOrCreate))
                {
                    image.SaveJpeg(stream, 173, 173, 0, 100);
                }
            }
            catch
            {
                return false;
            }
        }
        return true;
    }
 
