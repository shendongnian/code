    public Image FixedSize(Image imgPhoto, int Width, int Height, bool needToFill)
            {
                int sourceWidth = imgPhoto.Width;
                int sourceHeight = imgPhoto.Height;
                int sourceX = 0;
                int sourceY = 0;
                int destX = 0;
                int destY = 0;
    
                float nPercent = 0;
                float nPercentW = 0;
                float nPercentH = 0;
    
    			nPercentW = ((float)Width / (float)sourceWidth);
    			nPercentH = ((float)Height / (float)sourceHeight);
                if (!needToFill)
    			{
    				if (nPercentH < nPercentW)
    				{
    					nPercent = nPercentH;
    				}
    				else
    				{
    					nPercent = nPercentW;
    				}
    			}
    			else
    			{
    				if (nPercentH > nPercentW)
    				{
    					nPercent = nPercentH;
    					destX = (int)Math.Round((Width -
    						(sourceWidth * nPercent)) / 2);
    				}
    				else
    				{
    					nPercent = nPercentW;
    					destY = (int)Math.Round((Height -
    						(sourceHeight * nPercent)) / 2);
    				}
    			}
    
    			if (nPercent > 1)
    				nPercent = 1;
    			
                int destWidth = (int)Math.Round(sourceWidth * nPercent);
                int destHeight = (int)Math.Round(sourceHeight * nPercent);
    
                System.Drawing.Bitmap bmPhoto = new System.Drawing.Bitmap(
    				destWidth <= Width ? destWidth : Width, 
    				destHeight < Height ? destHeight : Height,
                                  PixelFormat.Format32bppRgb);
                //bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                //                 imgPhoto.VerticalResolution);
    
                System.Drawing.Graphics grPhoto = System.Drawing.Graphics.FromImage(bmPhoto);
                grPhoto.Clear(System.Drawing.Color.White);
                grPhoto.InterpolationMode = _interpolationMode;
                        //InterpolationMode.HighQualityBicubic;
                grPhoto.CompositingQuality = _compositingQuality;
                grPhoto.SmoothingMode = _smoothingMode;
    
                grPhoto.DrawImage(imgPhoto,
                    new System.Drawing.Rectangle(destX, destY, destWidth, destHeight),
                    new System.Drawing.Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                    System.Drawing.GraphicsUnit.Pixel);
    
                grPhoto.Dispose();
                return bmPhoto;
            }
