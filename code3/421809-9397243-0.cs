    // Pass in a rectangle
    private void SnapshotImage(Rectangle rect)
    {
        // Get me the screen coordinates, so that I get the correct area
        Point relativePosition = this.PointToScreen(rect.Location);
        // Create a new bitmap
        Bitmap bmp = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
        // Copy the image from screen
        using(Graphics g = Graphics.FromImage(bmp)) {
            g.CopyFromScreen(ptRelativePosition, Point.Empty, bmp.Size);
        }
        // Change the image to be the selected image area
        imageControl1.Image.ChangeImage(bmp);  
    }
