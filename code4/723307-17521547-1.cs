        public static void CropImage(int Width, int Height, string sourceFilePath, string saveFilePath) {
        // variable for percentage resize 
        float percentageResize = 0;
        float percentageResizeW = 0;
        float percentageResizeH = 0;
     
        // variables for the dimension of source and cropped image 
        int sourceX = 0;
        int sourceY = 0;
        int destX = 0;
        int destY = 0;
     
        // Create a bitmap object file from source file 
        Bitmap sourceImage = new Bitmap(sourceFilePath);
     
        // Set the source dimension to the variables 
        int sourceWidth = sourceImage.Width;
        int sourceHeight = sourceImage.Height;
     
        // Calculate the percentage resize 
        percentageResizeW = ((float)Width / (float)sourceWidth);
        percentageResizeH = ((float)Height / (float)sourceHeight);
     
        // Checking the resize percentage 
        if (percentageResizeH < percentageResizeW) {
            percentageResize = percentageResizeW;
            destY = System.Convert.ToInt16((Height - (sourceHeight * percentageResize)) / 2);
        } else {
            percentageResize = percentageResizeH;
            destX = System.Convert.ToInt16((Width - (sourceWidth * percentageResize)) / 2);
        }
     
        // Set the new cropped percentage image
        int destWidth = (int)Math.Round(sourceWidth * percentageResize);
        int destHeight = (int)Math.Round(sourceHeight * percentageResize);
     
        // Create the image object 
        using (Bitmap objBitmap = new Bitmap(Width, Height)) {
            objBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
            using (Graphics objGraphics = Graphics.FromImage(objBitmap)) {
                // Set the graphic format for better result cropping 
                objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                objGraphics.DrawImage(sourceImage, new Rectangle(destX, destY, destWidth, destHeight), new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight), GraphicsUnit.Pixel);
     
                // Save the file path, note we use png format to support png file 
                objBitmap.Save(saveFilePath, ImageFormat.Png);
                }
            }
        }
