    private stdole.IPictureDisp GetPictureMask(Bitmap img) {
    
    			if (img.IsNotNull()) {
    
    				int rgb;
    				Color c;
    
    				for (int y = 0; y < img.Height; y++)
    					for (int x = 0; x < img.Width; x++) {
    						c = img.GetPixel(x, y);
    						Color m = Color.Empty;
    
    						if (c.B == 0 && c.R == 0 && c.G == 0) {
    							m = Color.White;							
    						}
    						else {
    							m = Color.Black;
    						}
    
    						img.SetPixel(x, y, Color.FromArgb(c.A, m.R, m.G, m.B));
    					}
    
    				return IconConverter.GetIPictureDispFromImage(img);
    			}
    
    			return null;
    		}
