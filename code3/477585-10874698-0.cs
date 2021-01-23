    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        var points = new PointF[6] { new PointF(0, 0), new PointF(30, 3), new PointF(90, 0), new PointF(190, 3.1f), new PointF(270, -0.5f), new PointF(360, 3.5f) };
 
        float maxX = (from p in points select p).Max(t => t.X);
        float maxY = (from p in points select p).Max(t => t.Y);            
        float xSizeToFit = pictureBox1.Width;
        float ySizeToFit = pictureBox1.Height/2;
        float scaleX = xSizeToFit / maxX;
        float scaleY = ySizeToFit / maxY;
            
        // scale to fit to given size
        ScalePoints(points, scaleX, scaleY);
        // translate to center
        TranslatePoints(points, this.pictureBox1.Width / 2 - 0.5f * xSizeToFit, this.pictureBox1.Height / 2 + 0.5f * ySizeToFit);
        DrawAxis(e.Graphics, this.pictureBox1.Size);
        e.Graphics.DrawLines(Pens.Black, points);                
    }
    private void TranslatePoints(PointF[] points, float transX, float transY)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].X += transX;
            points[i].Y = transY - points[i].Y;
        }
    }
    private void ScalePoints(PointF[] points, float scaleX, float scaleY)
    {
        for (int i = 0; i < points.Length; i++)
        {
            points[i].X *= scaleX;
            points[i].Y *= scaleY;
        }
    }
    public void DrawAxis(Graphics g, Size size)
    {
        //x
        g.DrawLine(Pens.Black, 0, size.Height / 2, size.Width, size.Height / 2);
        //y
        g.DrawLine(Pens.Black, size.Width / 2, size.Height, size.Width / 2, 0);           
    }
    private void pictureBox1_Resize(object sender, EventArgs e)
    {
        pictureBox1.Invalidate();
    }
