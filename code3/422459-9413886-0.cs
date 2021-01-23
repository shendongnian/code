    Bitmap zz = new Bitmap(100, 100);
    
    using (Graphics g = Graphics.FromImage(zz))
    {
    	// Draws a black background
    	g.Clear(Color.Black);
    }
    
    Random rnd = new Random();
    for (int i = 0; i < zz.Height; i++)
    {
    	for (int j = 0; j < zz.Width; j++)
    	{
    		// Randomly add white pixels
    		if (rnd.NextDouble() > 0.5)
    		{
    			zz.SetPixel(i, j, Color.White);
    		}
    	}
    }
    
    zz.Save(@"C:\myfile.bmp", ImageFormat.Bmp);
