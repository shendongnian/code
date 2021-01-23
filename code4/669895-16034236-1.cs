      private bool IsBitonal(string FilePath)
      {
            System.Drawing.Image image1 = System.Drawing.Image.FromFile(FilePath);
    
            // Save the image in PNG format.
            image1.Save(<pngpath>, System.Drawing.Imaging.ImageFormat.Png);
    
    
            Bitmap bitmap = new Bitmap(FilePath);
            return (bitmap.PixelFormat == PixelFormat.Format1bppIndexed)   
      }
