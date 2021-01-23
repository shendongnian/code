       private static Image cropImage(Image img, Rectangle cropArea)
       {
           Bitmap bmpImage = new Bitmap(img);
           Bitmap bmpCrop = bmpImage.Clone(cropArea,
           bmpImage.PixelFormat);
           return (Image)(bmpCrop);
       }
