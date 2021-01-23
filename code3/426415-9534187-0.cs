           MemoryStream ms = new MemoryStream(File.ReadAllBytes(path));
           Bitmap originalBMP = new Bitmap(ms);
           int maxWidth = 200;
           int maxHeight = 200;
           // Calculate the new image dimensions 
           int origWidth = originalBMP.Width;
           int origHeight = originalBMP.Height;
           double sngRatio = Convert.ToDouble(origWidth) / Convert.ToDouble(origHeight);
           // New dimensions
           int newWidth = 0;
           int newHeight = 0;
           try
           {
               // max 200 by 200
               if ((origWidth <= maxWidth && origHeight <= maxHeight) || origWidth <= maxWidth)
               {
                   newWidth = origWidth;
                   newHeight = origHeight;
               }
               else
               {
                   // Width longer (shrink width)
                   newWidth = 200;
                   newHeight = Convert.ToInt32(Convert.ToDouble(newWidth) / sngRatio);
               }
               // Create a new bitmap which will hold the previous resized bitmap 
               Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
               // Create a graphic based on the new bitmap 
               Graphics oGraphics = Graphics.FromImage(newBMP);
               // Set the properties for the new graphic file 
               oGraphics.SmoothingMode = SmoothingMode.AntiAlias;
               oGraphics.InterpolationMode = InterpolationMode.High;
               // Draw the new graphic based on the resized bitmap 
               oGraphics.CompositingQuality = CompositingQuality.HighSpeed;
                
               oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
               // Save the new graphic file to the server 
               EncoderParameters p = new EncoderParameters(1);
               p.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Compression, 70);     // Percent Compression
               MemoryStream savedBmp = new MemoryStream();
               newBMP.Save(savedBmp, ImageCodecInfo.GetImageEncoders()[1], p);
                              // Once finished with the bitmap objects, we deallocate them. 
               originalBMP.Dispose();
               newBMP.Dispose();
               oGraphics.Dispose();
               savedBmp.Dispose();
