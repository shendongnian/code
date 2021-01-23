    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        base.OnPaint(e);
        using(Graphics g = e.Graphics)
        {
           var p = new Pen(Color.Black, 3);
           var point1 = new Point(234,118);
           var point2 = new Point(293,228);
           g.DrawLine(p, point1, point2);
        }
    }
