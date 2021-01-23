    WriteableBitmap bmpCurrentScreenImage = new WriteableBitmap((int)this.ActualWidth, (int)this.ActualHeight);
    bmpCurrentScreenImage.Render(LayoutRoot, new MatrixTransform());
    bmpCurrentScreenImage.Invalidate();
    using (var stream = new MemoryStream())
    {
        // Save the picture to the Windows Phone media library.
        bitmap.SaveJpeg(stream, bitmap.PixelWidth, bitmap.PixelHeight, 0, quality);
        stream.Seek(0, SeekOrigin.Begin);
        var picture = new MediaLibrary().SavePicture(name, stream);
        return picture.GetPath();
    }
