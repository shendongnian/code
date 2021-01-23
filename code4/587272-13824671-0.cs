    // get the BitmapImage
    var image = new BitmapImage(new Uri(path));
    if (image.PixelHeight != image.PixelWidth) return;
    Dimension = image.PixelHeight;
    
    // copy to byte array
    int stride = image.PixelWidth * 4;
    byte[] buffer = new byte[stride * image.PixelHeight];
    image.CopyPixels(buffer, stride, 0);
    
    // create a bitmap
    var bitmap = new System.Drawing.Bitmap(image.PixelWidth, image.PixelHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
    
    // lock bitmap data
    System.Drawing.Imaging.BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, bitmap.PixelFormat);
    
    // copy byte array to bitmap data
    System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bitmapData.Scan0, buffer.Length);
    
    // unlock
    bitmap.UnlockBits(bitmapData);
    
    // copy to Color array
    var colors = new Color[Dimension, Dimension];
    for (int i = 0; i < bitmap.Height; i++)
        for (int j = 0; j < bitmap.Width; j++)
        {
            var mediacolor = bitmap.GetPixel(i, j);
            var drawingcolor = Color.FromArgb(mediacolor.A, mediacolor.R, mediacolor.G, mediacolor.B);
            colors[i, j] = drawingcolor;
        }
