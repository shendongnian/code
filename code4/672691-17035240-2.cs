    private async void restoreImage(object value)
    {
        if (value != null)
        {
            mruToken = value.ToString();
            // Open the file via the token that you stored when adding this file into the MRU list.
            Windows.Storage.StorageFile file =
                await Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList.GetFileAsync(mruToken);
            if (file != null)
            {
                // Open a stream for the selected file.
                Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                // Set the image source to a bitmap.
                Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImage =
                    new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                bitmapImage.SetSource(fileStream);
                displayImage.Source = bitmapImage;
                // Set the data context for the page.
                this.DataContext = file;
            }
        }
    }
