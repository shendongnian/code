    BitmapSource bmpSource = msg.ThumbnailSource as BitmapSource;
    MemoryStream ms = new MemoryStream();
    BitmapEncoder encoder = new PngBitmapEncoder();
    encoder.Frames.Add(BitmapFrame.Create(bmpSource));
    encoder.Save(ms);
    ms.Seek(0, SeekOrigin.Begin);
    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);
