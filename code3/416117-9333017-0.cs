    void DrawRectangle(Graphics g, Color pencolor, int penwidth, Rectangle x)
    {
        if(x.Width < penwidth || x.Height < penHeight)
        {
            Pen p = new Pen(pencolor);
            p.Alignment = PenAlignment.Inset;
            g.FillRectangle(p, x);
            p.Dispose();
        }
        else
        {
            Pen p = new Pen(pencolor, penwidth);
            p.Alignment = PenAlignment.Inset;
            g.DrawRectangle(p, x);
            p.Dispose();
        }
    }
