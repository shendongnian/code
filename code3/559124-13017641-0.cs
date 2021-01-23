    private Point _lastPoint;
    protected void MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
        Graphics g = CreateGraphics();
        g.LineTo(_lastPoint.X, _lastPoint.Y, e.X, e.Y);
    }
