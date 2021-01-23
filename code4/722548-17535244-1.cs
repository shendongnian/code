    public System.Drawing.Image GetMapImage()
    {
    	RenderTargetBitmap rtb = new RenderTargetBitmap((int)this.mapControl1.ActualWidth, (int)this.mapControl1.ActualHeight, 96, 96, PixelFormats.Pbgra32);
    	rtb.Render(this.mapControl1);
    	PngBitmapEncoder png = new PngBitmapEncoder();
    	png.Frames.Add(BitmapFrame.Create(rtb));
    	MemoryStream stream = new System.IO.MemoryStream();
    	png.Save(stream);
    	System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
    
    	return image;
    }
    void PrintDoc_PrintPage(object sender, PrintPageEventArgs e)
    {
    	// Get the current map image. do not continue, if no image.
    	Image oMapResized = ((bvMaps.MapDevex)this.mapMain.Child).GetMapImage();
    	if (null == oMapResized)
    		return;
    
    	// Draw the image on the paper starting at the upper left corner.
    	e.Graphics.DrawImage((Image)oMapResized, new Point(0, 0));
    }
