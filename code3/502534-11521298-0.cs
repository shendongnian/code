    private void Form1_Resize(object sender, System.EventArgs e)
    {
        //Generate your mapDrawer object here, as you have been doing already
    
        mapDrawer.DrawImage( map1,
            new RectangleF(0, 0, ImageSizeX * scale, ImageSizeY * scale),
            new RectangleF(0, 0, ImageSizeX, ImageSizeY),
            GraphicsUnit.Pixel);
    }
