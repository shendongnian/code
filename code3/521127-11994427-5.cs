    /// <summary>
    /// Saves a picture of the screen to a bitmap image.
    /// </summary>
    /// <returns>The saved bitmap.</returns>
    private Bitmap CaptureScreenShot()
    {
     	// get the bounding area of the screen containing (0,0)
        // remember in a multidisplay environment you don't know which display holds this point
        Rectangle bounds = Screen.GetBounds(Point.Empty);
     
        // create the bitmap to copy the screen shot to
       	Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
     
        // now copy the screen image to the graphics device from the bitmap
       	using (Graphics gr = Graphics.FromImage(bitmap))
       	{
           	   gr.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
       	}
     
      	return bitmap;
    }
