    static class Imaging
    {
        public static bool AnnotateImage(string sFilePath, string sText)
        {
            try
            {
                // Get an ImageCodecInfo object that represents the TIFF codec.
                ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/tiff");
                Encoder myEncoder = Encoder.Compression;
                EncoderParameters myEncoderParameters = new EncoderParameters(1);
                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, (long)EncoderValue.CompressionCCITT4);
                myEncoderParameters.Param[0] = myEncoderParameter;
                //Create some global variables
                Point pointPosition = new Point(0, 0);
                PointF pPos = new PointF((float)pointPosition.X, (float)pointPosition.Y);
                Bitmap newBmp;
                Graphics g;
                Font fNewFont;
                SizeF sizeTextSize;
                Rectangle rectTextSize;
                //Set inital width and height variables
                int iW;
                int iH;
                int iAnnotationH = 44;
                using(Image iSource = Image.FromFile(sFilePath))
                {
                    iW = iSource.Width;
                    iH = iSource.Height;
                    //Increase the height of the image
                    iH += iAnnotationH;
                    //Create the new bitmap object
                    newBmp = new Bitmap(iW, iH);
                    newBmp.SetResolution(200.0F, 200.0F);
                    g = Graphics.FromImage(newBmp);
                    g.Clear(Color.White);
                    g.DrawImageUnscaled(iSource, 0, iAnnotationH, iW, iH);
                    //Create the font object to draw the annotation text
                    fNewFont = new Font("Verdana", 12);
                    //Get the size of the area to be drawn then convert it to a rect
                    sizeTextSize = g.MeasureString(sText, fNewFont);
                    rectTextSize = new Rectangle(pointPosition.X, pointPosition.Y, (int)sizeTextSize.Width, (int)sizeTextSize.Height);
                    //Draw a white rect
                    g.FillRectangle(Brushes.White, rectTextSize);
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                    g.DrawString(sText, fNewFont, Brushes.Black, pPos);
                }
                //Save the changed image
                newBmp.Save(sFilePath, myImageCodecInfo, myEncoderParameters);
            }
            catch
            {
                return false;
            }
            return true;
        }
        static ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
