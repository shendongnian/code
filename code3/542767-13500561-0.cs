    // this code assumes that the pixel 0, 0 (the pixel at the top, left corner) 
    // of the bitmap passed contains the color you  wish to make transparent.
    
           private static Region CreateRegion(Bitmap maskImage) {
               Color mask = maskImage.GetPixel(0, 0);
               GraphicsPath grapicsPath = new GraphicsPath(); 
               for (int x = 0; x < maskImage.Width; x++) {
                   for (int y = 0; y < maskImage.Height; y++) {
                       if (!maskImage.GetPixel(x, y).Equals(mask)) {
                               grapicsPath.AddRectangle(new Rectangle(x, y, 1, 1));
                           }
                       }
               }
    
               return new Region(grapicsPath);
           }
