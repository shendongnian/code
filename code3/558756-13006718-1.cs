    async private void LoadImage()
    {
        try
        {
            IReadOnlyList<Windows.Storage.StorageFile> resultsLibrary =
                await Windows.Storage.KnownFolders.PicturesLibrary.GetFilesAsync();
            MessageBlock.Text += "Show image: " + resultsLibrary[0].Name + "\n";
            Windows.Storage.Streams.IRandomAccessStream imageStream =
                await resultsLibrary[0].OpenAsync(Windows.Storage.FileAccessMode.Read);
            Windows.UI.Xaml.Media.Imaging.BitmapImage imageBitmap =
                new Windows.UI.Xaml.Media.Imaging.BitmapImage();
            imageBitmap.SetSource(imageStream);
            ImagePlayer.Source = imageBitmap;
        }
        catch (Exception ex)
        {
            MessageBlock.Text += "Exception encountered: " + ex.Message + "\n";
        }
    }
