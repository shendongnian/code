    static public void SaveCapturedImageFromClipBoard(Stream target)
    {
        var img = new System.Windows.Controls.Image();
        var imgsrc = Clipboard.GetImage();
        img.Source = new FormatConvertedBitmap(imgsrc, PixelFormats.Bgr32, null, 0);
        JpegBitmapEncoder encoder = new JpegBitmapEncoder();
        encoder.Frames.Add(BitmapFrame.Create(imgsrc));
        encoder.Save(target);
    }
