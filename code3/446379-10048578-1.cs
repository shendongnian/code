    Color pixelColor;
    
    // add the mouse click event handler in designer mode or:
    // myPicturebox.MouseClick += new MouseEventHandler(myPicturebox_MouseClick);
    private void myPicturebox_MouseClick(object sender, MouseEventArgs e) {
       if (e.Button == MouseButtons.Left) 
          pixelColor = GetClickedPixel(e.Location);
    }
    
    private Color GetClickedPixel(Point point) {
       return ((Bitmap)myPicturebox.Image).GetPixel(point.X, point.Y);
    }
