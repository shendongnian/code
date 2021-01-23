    public async Task<Image> GetImageAsync(StorageFile storageFile)
    {
            BitmapImage bitmapImage = new BitmapImage();
            FileRandomAccessStream stream = (FileRandomAccessStream)await storageFile.OpenAsync(FileAccessMode.Read);
            bitmapImage.SetSource(stream);
            Image image = new Image();
            image.Source = bitmapImage;
            return image;
    }
