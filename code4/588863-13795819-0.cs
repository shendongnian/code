    Region rgn = new Region(new Rectangle(50, 50, 200, 150));
    System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
    path.AddEllipse(60, 60, 100, 100);
    rgn.Exclude(path);
    Graphics g = this.CreateGraphics();
    g.FillRegion(Brushes.Blue, rgn);
