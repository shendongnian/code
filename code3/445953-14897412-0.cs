    void Form1_Paint(object sender, PaintEventArgs e)
    {
        using (Bitmap bitmap = new Bitmap(500, 500))
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.White);
                List<Point> points = new List<Point>();
                for (double i = 0; i < 10; i++)
                {
                    double dist = (i % 2 == 0) ? 100 : 50;
                    double x = 200 + Math.Cos(i / 10d * Math.PI * 2d) * dist;
                    double y = 200 + Math.Sin(i / 10d * Math.PI * 2d) * dist;
                    points.Add(new Point((int)x, (int)y));
                }
                g.DrawPolygon(Pens.Black, points.ToArray());
            }
    
            FloodFill(bitmap, 200, 200, Color.Red);
    
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
    
    void FloodFill(Bitmap bitmap, int x, int y, Color color)
    {
        BitmapData data = bitmap.LockBits(
            new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
        int[] bits = new int[data.Stride / 4 * data.Height];
        Marshal.Copy(data.Scan0, bits, 0, bits.Length);
    
        LinkedList<Point> check = new LinkedList<Point>();
        int floodTo = color.ToArgb();
        int floodFrom = bits[x + y * data.Stride / 4];
        bits[x + y * data.Stride / 4] = floodTo;
    
        if (floodFrom != floodTo)
        {
            check.AddLast(new Point(x, y));
            while (check.Count > 0)
            {
                Point cur = check.First.Value;
                check.RemoveFirst();
    
                foreach (Point off in new Point[] {
                    new Point(0, -1), new Point(0, 1), 
                    new Point(-1, 0), new Point(1, 0)})
                {
                    Point next = new Point(cur.X + off.X, cur.Y + off.Y);
                    if (next.X >= 0 && next.Y >= 0 &&
                        next.X < data.Width &&
                        next.Y < data.Height)
                    {
                        if (bits[next.X + next.Y * data.Stride / 4] == floodFrom)
                        {
                            check.AddLast(next);
                            bits[next.X + next.Y * data.Stride / 4] = floodTo;
                        }
                    }
                }
            }
        }
    
        Marshal.Copy(bits, 0, data.Scan0, bits.Length);
        bitmap.UnlockBits(data);
    }
