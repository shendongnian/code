            /// <summary>
            /// Scales to within given boundaries - Aspect ratio is kept. High Quality Bi-Cubic interpolation is used.
            /// If boundary is larger than the image, then image is scaled up; if smaller, it is scaled down.
            /// </summary>
            /// <param name="originalImg">Image: Image to scale</param>
            /// <param name="width">Int: Restriction on width for output size. Must be greater than zero</param>
            /// <param name="height">Int: Restriction on height for output size. Must be greater than zero</param>
            /// <param name="backgroundColour">Color: Colour to shade background behind image</param>
            /// <returns>Image: Scaled Image</returns>
            /// <exception cref="ArgumentException">[ArgumentException] Boundary dimensions must exceed zero</exception>
            public static Image ScaleToFit(Image originalImg, int width, int height, Color backgroundColour)
            {
                if (originalImg == null) return null;
                if (width < 1 || height < 1) throw new ArgumentException("ScaleToFit: Boundary dimensions must exceed zero.");
    
                var destX = 0;
                var destY = 0;
                float nPercent;
    
                var nPercentW = (width / (float)originalImg.Width);
                var nPercentH = (height / (float)originalImg.Height);
                if (nPercentH < nPercentW)
                {
                    nPercent = nPercentH;
                    destX = Convert.ToInt16((width - (originalImg.Width * nPercent)) / 2);
                }
                else
                {
                    nPercent = nPercentW;
                    destY = Convert.ToInt16((height - (originalImg.Height * nPercent)) / 2);
                }
    
                var destWidth = (int)(originalImg.Width * nPercent);
                var destHeight = (int)(originalImg.Height * nPercent);
    
                var bmPhoto = new Bitmap(width, height, PixelFormat.Format24bppRgb);
                bmPhoto.SetResolution(originalImg.HorizontalResolution, originalImg.VerticalResolution);
    
                var grPhoto = Graphics.FromImage(bmPhoto);
                grPhoto.Clear(backgroundColour);
                grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
                grPhoto.DrawImage(originalImg,
                    new Rectangle(destX, destY, destWidth, destHeight),
                    new Rectangle(0, 0, originalImg.Width, originalImg.Height),
                    GraphicsUnit.Pixel);
    
                grPhoto.Dispose();
                return bmPhoto;
            }
