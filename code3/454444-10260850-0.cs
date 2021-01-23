        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            Region r;
            PointF[] p = new PointF[9];
            p[0] = new PointF(70, 0);
            p[1] = new PointF(170, 0);
            p[2] = new PointF(240, 70);
            p[3] = new PointF(240, 170);
            p[4] = new PointF(170, 240);
            p[5] = new PointF(70, 240);
            p[6] = new PointF(0, 170);
            p[7] = new PointF(0, 70);
            p[8] = new PointF(70, 0);
            gp.AddPolygon(p);
            r = new Region(gp);
            this.Region = r;
            gp.Dispose();
            r.Dispose();
        }
