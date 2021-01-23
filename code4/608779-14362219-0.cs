    Bitmap b = new Bitmap(30, 30);
    using (Graphics g = Graphics.FromImage(b))
    {
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        g.Clear(Color.Black);
        g.FillPolygon(Brushes.White, new Point[] {
            new Point(5,5),
            new Point(20,20),
            new Point(2,15)});
    }
    byte[,] mask = new byte[b.Width, b.Height];
    for (int y = 0; y < b.Height; y++)
    for (int x = 0; x < b.Width; x++)
    {
        mask[x, y] = b.GetPixel(x, y).R > 0 ? 1 : 0;
    }
