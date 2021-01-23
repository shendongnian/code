    public static byte[] ConvertFromPNG(Bitmap PNG)
    {
        byte[] rgbaB = new byte[4 * (PNG.Width * PNG.Height)];
    
        int i = 0;
    
        for (var y = 0; y < PNG.Height; y++)
        {
    		for (var x = 0; x < PNG.Width; x++)
    		{
    			Color pix = PNG.GetPixel(x, y);
    
    			rgbaB[i++] = pix.R;
    			rgbaB[i++] = pix.G;
    			rgbaB[i++] = pix.B;
    			rgbaB[i++] = pix.A;
    		}
        }
    
        return rgbaB;
    }
