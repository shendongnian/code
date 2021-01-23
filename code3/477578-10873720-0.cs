    IsolatedStorageFile Store = IsolatedStorageFile.GetUserStoreForApplication();
    if (Store.FileExists("Images/app.jpg"))
    {
        try
        {
            using (IsolatedStorageFileStream Stream = new IsolatedStorageFileStream(Path, FileMode.Open, FileAccess.Read, Store))
            {
                if (Stream.Length > 0)
                {
                    BitmapImage Image = new BitmapImage();
                    Image.SetSource(Stream);
                    this.LayoutRoot.Background = Image;
                }
            }
        }
        catch (Exception)
        {
            return new BitmapImage();
        }
    }
