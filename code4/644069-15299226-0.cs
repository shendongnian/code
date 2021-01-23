    public MyRectangles(Graphics g, int x, int y)
    {
        Pen p = new Pen(Color.Turquoise, 2);
        Rectangle r = new Rectangle(x, y, 5, 5);
        g.DrawRectangle(p, r);
        p.Dispose();
    }
