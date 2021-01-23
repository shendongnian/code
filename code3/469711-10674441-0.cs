    protected override void OnPaint(PaintEventArgs e)
        {
            var th = 10.0f;
            var picLander = new PointF(0.5f, 0.5f);
    
    
            Graphics g = e.Graphics;
            g.PageUnit = GraphicsUnit.Inch;
            Pen MyPen = new Pen(Color.Black, th / g.DpiX);
            g.DrawLine(MyPen, Convert.ToInt32(picLander.X), Convert.ToInt32(picLander.Y), 1, 1);
            g.DrawEllipse(MyPen, Convert.ToInt32(picLander.X), Convert.ToInt32(picLander.Y), 3, 5);
        }
