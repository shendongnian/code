        private int[] getHistogram( BitmapData imageData )
        {
            int width = imageData.Width;
            int height = imageData.Height;
			int offset = imageData.Stride - width * 3;
            int[] l = new int[256];
            unsafe
            {
                byte * p = (byte *) imageData.Scan0.ToPointer( );
                // for each line
                for ( int y = 0; y < height; y++ )
                {
                    // for each pixel
                    for ( int x = 0; x < width; x++, p += 3 )
                    {
                        int bright = p[RGB.R] + p[RGB.G] + p[RGB.B];
						bright /= 3;
						
						l[bright]++;
                    }
                    p += offset;
                }
            }
			
			return l; 
        }
  
