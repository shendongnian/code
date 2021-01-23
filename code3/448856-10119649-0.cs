    System.Drawing.Graphics g = this.CreateGraphics();
        System.Drawing.BufferedGraphicsContext dc = new BufferedGraphicsContext();
        BufferedGraphics backbuffer = dc.Allocate(g, new Rectangle(new Point(0, 0), g.VisibleClipBounds.Size.ToSize()));
        backbuffer.Graphics.DrawLine(Pens.White, 10, 10, 10, 100);
        backbuffer.Render(g);
