    Color pixelcolor;
    
    private void picturebox1_MouseClick(object sender, MouseEventArgs e)
    {
       if (e.Button == MouseButtons.Left) pixelcolor = GetClickedPixel(e.Location);
    }
    
    private Color GetClickedPixel(Point point)
    {
       Bitmap bitmap = (Bitmap)picturebox1.Image;
       return bitmap.GetPixel(point.X, point.Y);
    }
