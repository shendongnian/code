    private void SaveImage(string path)
    {
        var jpegEncoder = new JpegBitmapEncoder();
        jpegEncoder.Frames.Add(BitmapFrame.Create(colorImageWritableBitmap));
        using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
        {
            jpegEncoder.Save(fs);
        }
    }
