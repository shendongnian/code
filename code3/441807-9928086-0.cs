    void panel1_Paint(object sender, PaintEventArgs e)
        float percent = 0.75f;
        RectangleF bounds = new RectangleF(20, 20, 80, 200);
        FillEllipse(e.Graphics, bounds, percent);
    }
    static void FillEllipse(Graphics g, RectangleF bounds, float percent) {
        g.DrawEllipse(Pens.Red, bounds);
        g.SetClip(new RectangleF(
            bounds.X,
            bounds.Y + (1f - percent) * bounds.Height,
            bounds.Width,
            percent * bounds.Height));
    
        g.FillEllipse(Brushes.Red, bounds);
        g.ResetClip();
    }
