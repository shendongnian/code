    Graphics g = e.Graphics;
    
    Point p1 = new Point(20, 20);
    Point p2 = new Point(50, 50);
    
    g.DrawLine(Pens.Red, p1, p2);
    g.FillEllipse(Pens.Red, p1.X - 2, p1.Y - 2, 4, 4);
    g.FillEllipse(Pens.Red, p2.X - 2, p2.Y - 2, 4, 4);
