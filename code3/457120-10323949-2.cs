    public static System.Drawing.Image FixedSize(Image image, int Width, int Height, bool needToFill)
            {
                #region много арифметики
                int sourceWidth = image.Width;
                int sourceHeight = image.Height;
                int sourceX = 0;
                int sourceY = 0;
                double destX = 0;
                double destY = 0;
    
                double nScale = 0;
                double nScaleW = 0;
                double nScaleH = 0;
    
                nScaleW = ((double)Width / (double)sourceWidth);
                nScaleH = ((double)Height / (double)sourceHeight);
                if (!needToFill)
                {
                    nScale = Math.Min(nScaleH, nScaleW);
                }
                else
                {
                    nScale = Math.Max(nScaleH, nScaleW);
                    destY = (Height - sourceHeight * nScale) / 2;
                    destX = (Width - sourceWidth * nScale) / 2;
                }
    
                if (nScale > 1)
                    nScale = 1;
    
                int destWidth = (int)Math.Round(sourceWidth * nScale);
                int destHeight = (int)Math.Round(sourceHeight * nScale);
                #endregion
    
                System.Drawing.Bitmap bmPhoto = null;
                try
                {
                    bmPhoto = new System.Drawing.Bitmap(destWidth + (int)Math.Round(2 * destX), destHeight + (int)Math.Round(2 * destY));
                }
                catch (Exception ex)
                {
                    throw new ApplicationException(string.Format("destWidth:{0}, destX:{1}, destHeight:{2}, desxtY:{3}, Width:{4}, Height:{5}",
                        destWidth, destX, destHeight, destY, Width, Height), ex);
                }
                using (System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto))
                {
                    grPhoto.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    grPhoto.CompositingQuality = CompositingQuality.HighQuality;
                    grPhoto.SmoothingMode = SmoothingMode.HighQuality;
    
                    Rectangle to =  new System.Drawing.Rectangle((int)Math.Round(destX), (int)Math.Round(destY), destWidth, destHeight);
                    Rectangle from = new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight);
                    //Console.WriteLine("From: " + from.ToString());
                    //Console.WriteLine("To: " + to.ToString());
                    grPhoto.DrawImage(image, to, from, System.Drawing.GraphicsUnit.Pixel);
    
                    return bmPhoto;
                }
            }
