    Point p1 = new Point(1,0);
    Point p2 = new Point(10, 3);
    Point p3 = new Point(9, 13);
    Point p4 = new Point(3,2);
    Point p = new Point(5,5);
    GraphicsPath g = new GraphicsPath();
    g.AddPolygon(new Point[] { p1, p2, p3, p4 });
    var result = g.IsVisible(p);
