    private Point? _start;
    private Rectangle _previousBounds;
    
    protected override void OnMouseDown(MouseEventArgs e)
    {
        _start = e.Location;
        base.OnMouseDown(e);
    }
    
    protected override void OnMouseMove(MouseEventArgs e)
    {
        if( _start.HasValue )
            DrawFrame(e.Location);
    
        base.OnMouseMove(e);
    }
    
    protected override void OnMouseUp(MouseEventArgs e)
    {
        ReverseFrame();
        _start = null;
        base.OnMouseUp(e);
    }
    
    private void ReverseFrame()
    {
        ControlPaint.DrawReversibleFrame(_previousBounds, Color.Red, FrameStyle.Dashed);
                
    }
    private void DrawFrame(Point end)
    {
        ReverseFrame();
    
        var size = new Size(end.X - _start.Value.X, end.Y - _start.Value.Y);
        _previousBounds = new Rectangle(_start.Value, size);
        _previousBounds = this.RectangleToScreen(_previousBounds);
        ControlPaint.DrawReversibleFrame(_previousBounds, Color.Red, FrameStyle.Dashed);
    }
