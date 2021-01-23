        Bitmap bmpPicture = new Bitmap(nameNumber + ".bmp");
    
        // jagged instead of multidimensional 
        int[][] GRAY = new int[3840][]; //Matrix with "grayscales" in INTeger values
        for (int i = 0, icnt = GRAY.Length; i < icnt; i++)
            GRAY[i] = new int[2748];
        unsafe
        {
            //create an empty bitmap the same size as original
            Bitmap bmp = new Bitmap(bmpPicture.Width, bmpPicture.Height);
    
            //lock the original bitmap in memory
            BitmapData originalData = bmpPicture.LockBits(
               new Rectangle(0, 0, bmpPicture.Width, bmpPicture.Height),
               ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
    
            //lock the new bitmap in memory
            BitmapData newData = bmp.LockBits(
               new Rectangle(0, 0, bmpPicture.Width, bmpPicture.Height),
               ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
    
            //set the number of bytes per pixel
            // here is set to 3 because I use an Image with 24bpp
            const int pixelSize = 3; // const because it doesn't change
            // store Scan0 value for reuse...we don't know if BitmapData caches it internally, or recalculated it every time, or whatnot
            int originalScan0 = originalData.Scan0;
            int newScan0 = newData.Scan0;
            // incrementing variables
            int originalStride = originalData.Stride;
            int newStride = newData.Stride;
            // store certain properties, because accessing a variable is normally faster than a property (and we don't really know if the property recalculated anything internally)
            int bmpwidth = bmpPicture.Width;
            int bmpheight = bmpPicture.Height;
    
            for (int y = 0; y < bmpheight; y++)
            {
                //get the data from the original image
                byte* oRow = (byte*)originalScan0 + originalStride++; // by doing Variable++, you're saying "give me the value, then increment one" (Tip: DON'T add parenthesis around it!)
    
                //get the data from the new image
                byte* nRow = (byte*)newScan0 + newStride++;
    
                int pixelPosition = 0;
                for (int x = 0; x < bmpwidth; x++)
                {
                    //create the grayscale version
                    byte grayScale =
                       (byte)((oRow[pixelPosition] * .114f) + //B
                       (oRow[pixelPosition + 1] * .587f) +  //G
                       (oRow[pixelPosition + 2] * .299f)); //R
    
                    //set the new image's pixel to the grayscale version
                    //   nRow[pixelPosition] = grayScale; //B
                    //   nRow[pixelPosition + 1] = grayScale; //G
                    //   nRow[pixelPosition + 2] = grayScale; //R
    
                    GRAY[x][y] = (int)grayScale;
                    pixelPosition += pixelSize;
                }
            }
