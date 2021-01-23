    var g = this.CreateGraphics();
    var points = new Point[6]{new Point(0, 0), new Point(10, 10), new Point(30, 0), new Point(40,20), new Point(50, 0), new Point(60,30)};
    g.TranslateTransform(Width / 2, 0, System.Drawing.Drawing2D.MatrixOrder.Append);
    for (int i = 0; i < points.Length-1; i++)
    {
        g.DrawLine(Pens.Black, points[i].X, Height / 2 - points[i].Y, points[i + 1].X, Height / 2 - points[i + 1].Y);
    }
