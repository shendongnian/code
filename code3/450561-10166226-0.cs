    Rectangle areaRect = new Rectangle(100, 100, 300, 300);
    bool dragging = false;
    bool rotating = false;
    Point ptOld = new Point(0, 0);
    float angle = 0;
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics dcPaint = e.Graphics;
        dcPaint.RotateTransform(angle);
        dcPaint.DrawRectangle(Pens.Black, areaRect);
        dcPaint.RotateTransform(-angle);
    }
    protected override void OnMouseDown(MouseEventArgs e)
    {
        ptOld = new Point(e.X, e.Y);
        if (e.Button == MouseButtons.Left)
        {
            dragging = true;
        }
        if (e.Button == MouseButtons.Right)
        {
            rotating = true;
        }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (dragging == true)
        {
            Point ptNew = new Point(e.X, e.Y);
            int dx = ptNew.X - ptOld.X;
            int dy = ptNew.Y - ptOld.Y;
            areaRect.Offset(dx, dy); // This one moves the rectangle 
            ptOld = ptNew;
            this.Invalidate();
        }
        if (rotating == true)
        {
            Point ptNew = new Point(e.X, e.Y);
            int dx = ptNew.X - ptOld.X;
            angle = angle + dx / 10f;
            ptOld = ptNew;
            this.Invalidate();
        }
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        dragging = false;
        rotating = false;
    }
