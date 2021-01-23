    using (Bitmap bmp = new Bitmap(webStream))
    {
         using (Bitmap newImage = new Bitmap(bmp))
         {
            newImage.SetResolution(bmp.HorizontalResolution, bmp.VerticalResolution);
            Rectangle lockedRect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            BitmapData bmpData = newImage.LockBits(lockedRect, ImageLockMode.ReadWrite, bmp.PixelFormat);
            bmpData.PixelFormat = bmp.PixelFormat;
            newImage.UnlockBits(bmpData);
            using (Graphics gr = Graphics.FromImage(newImage))
             {
                 gr.SmoothingMode = SmoothingMode.HighQuality;
                 gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                 gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
             }
             foreach (var item in bmp.PropertyItems)
             {
                 newImage.SetPropertyItem(item);
             }
             newImage.Save("c:\temp\test.jpg", ImageFormat.Jpeg);
        }
    }
