    List<PointF> points = new List<PointF>();
    Pen graphPen = new Pen(Color.Red, 2);
    
    private void btnDrawLines_Click(object sender, EventArgs e)
    {
        Graphics g = picBox.CreateGraphics();
        PointF pt1D = new PointF();
        PointF pt2D = new PointF();
        pt1D.X = 0;
        pt1D.Y = 10;
        pt2D.X = 10;
        pt2D.Y = 10;    
        g.DrawLine(graphPen, pt1D, pt2D);
        points.Add(pt1D);
        points.Add(pt2D);
    }
    
    private void picBox_Paint(object sender, PaintEventArgs e)
    {
        for (int i = 0; i < points.Count; i+=2)
            e.Graphics.DrawLine(graphPen, points[i], points[i + 1]);
    }
