    public BitmapImage Import(string path, bool isRelativePath)
    {
        var fullPath = GetFullPath(path, isRelativePath);
        var buffer = File.ReadAllBytes(fullPath);
        MemoryStream stream = new MemoryStream(buffer);
        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();
        return bitmapImage;
    }
    public BitmapImage BitmapToBitmapImage(Bitmap bitmap)
    {
        var stream = new MemoryStream();
        bitmap.Save(stream, ImageFormat.Png);
        var bitmapImage = new BitmapImage();
        bitmapImage.BeginInit();
        bitmapImage.StreamSource = stream;
        bitmapImage.EndInit();
        return bitmapImage;
    }
    public string GetFullPath(string path, bool isRelativePath)
    {
        return isRelativePath ? FolderPaths.Application + @"\" + path : path;
    }
