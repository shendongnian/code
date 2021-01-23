    Rectangle areaRect = new Rectangle(100,100, 300, 300);
    Point ptOld = new Point(0, 0);
    Pen rectPen = new Pen(Brushes.White, 3);
    //A new field with a semi-transparent brush to paint the outside of the rectangle
    Brush dimmingBrush = new SolidBrush(Color.FromArgb(128, 0, 0, 0));
    protected override void OnPaint(PaintEventArgs e)
    {
        Region outsideRegion = new System.Drawing.Region(e.ClipRectangle);
        outsideRegion.Exclude(areaRect);
        Graphics dcPaint = e.Graphics;
        dcPaint.FillRegion(dimmingBrush, outsideRegion);
        dcPaint.DrawRectangle(rectPen, areaRect);
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        Point ptNew = new Point(e.X, e.Y);
        int dx = ptNew.X - ptOld.X;
        int dy = ptNew.Y - ptOld.Y;
        areaRect.Offset(dx, dy);
        MoveRect(ptNew);
        ptOld = ptNew;
        this.Invalidate();
    }
