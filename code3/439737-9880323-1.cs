    private void showHSV(Bitmap bmp)
    {
        Image<Bgr, byte> img = new Image<Bgr, byte>(bmp); // Not sure what Image<,> is, but I guess it needs disposing at some point
        Image<Hsv, byte> imgHsv = img.Convert<Hsv, byte>(); // same here
        Bitmap bmp2 = imgHsv.ToBitmap(); // bmp2 is never disposed in your code
        var oldBmp = image2.Source;
        image2.Source = sourceFromBitmap(bmp2);
        oldBmp.Dispose() // try this
    }
    private BitmapSource sourceFromBitmap(Bitmap bmp)
    {
        BitmapSource bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
            bmp.GetHbitmap(),
            IntPtr.Zero,
            System.Windows.Int32Rect.Empty,
            BitmapSizeOptions.FromWidthAndHeight(bmp.Width, bmp.Height));
        return bs;
    }
    private void ColorImageReady(object sender, ColorImageFrameReadyEventArgs e)
    {
        using (ColorImageFrame imageFrame = e.OpenColorImageFrame())
        {
            if (imageFrame != null)
            {   
                byte[] pixelData = new byte[imageFrame.PixelDataLength];
                imageFrame.CopyPixelDataTo(pixelData);
                BitmapSource bmp = BitmapImage.Create(imageFrame.Width, imageFrame.Height, 96, 96, PixelFormats.Bgr32, null,
                    pixelData, imageFrame.Width * imageFrame.BytesPerPixel); // bmp never disposed
                var oldBmp = image1.Source;
                image1.Source = bmp;
                oldBmp.Dispose(); // try so
                showHSV(bitmapFromSource(bmp)); // what happens inside? bmp needs to be disposed at some point...
            }
            else
            {
                // imageFrame is null because the request did not arrive in time          }
            }
        }
    }
    private System.Drawing.Bitmap bitmapFromSource(BitmapSource bitmapsource)
    {
        System.Drawing.Bitmap bitmap;
        using (System.IO.MemoryStream outStream = new System.IO.MemoryStream())
        {
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(bitmapsource));
            enc.Save(outStream);
            bitmap = new System.Drawing.Bitmap(outStream);
        }
        return bitmap;
    }
