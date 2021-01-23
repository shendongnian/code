    public static Image ResizeImage(Image imgToResize, Size size)
    		{
    			try
    			{
    				Bitmap b = new Bitmap(size.Width, size.Height);
    				using (Graphics g = Graphics.FromImage((Image)b))
    				{
    					g.InterpolationMode = InterpolationMode.HighQualityBicubic;
    
    					g.DrawImage(imgToResize, 0, 0, size.Width, size.Height);
    				}
    
    				return (Image)b;
    			}
    			catch
    			{
    				throw;
    			}
    		}
