	// Determine the size of the "virtual screen", which includes all monitors.
	int screenWidth  = SystemInformation.VirtualScreen.Width;
	int screenHeight = SystemInformation.VirtualScreen.Height;
	
	// Create a bitmap of the appropriate size to receive the screenshot.
	using (Bitmap bmp = new Bitmap(screenWidth, screenHeight))
	{
		// Draw the screenshot into our bitmap.
		using (Graphics g = Graphics.FromImage(bmp))
		{
			g.CopyFromScreen(0, 0, 0, 0, bmp.Size);
		}
		
		// Do something with the Bitmap here, like save it to a file:
		bmp.Save(savePath, ImageFormat.Jpeg);
	}
	
