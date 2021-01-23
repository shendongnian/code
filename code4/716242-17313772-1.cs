    // The original bitmap with the wrong pixel format. 
    // You can check the pixel format with originalBmp.PixelFormat
    Bitmap originalBmp = new (Bitmap)Image.FromFile("YourFileName.gif");
    // Create a blank bitmap with the same dimensions
    Bitmap tempBitmap = new Bitmap(originalBmp.Width, originalBmp.Height);
    // From this bitmap, the graphics can be obtained, because it has the right PixelFormat
    using(Graphics g = Graphics.FromImage(tempBitmap))
    {
        // Draw the original bitmap onto the graphics of the new bitmap
        g.DrawImage(originalBmp, 0, 0);
        // Use g to do whatever you like
        g.DrawLine(...);
    }
    // Use tempBitmap as you would have used originalBmp
    return tempBitmap;
