    Point? startPoint;
    Point? endPoint;
    
    private void Form_MouseDown(object sender, MouseEventArgs e)
    {
        startPoint = PointToScreen(e.Location);
    }
    
    private void Form_MouseMove(object sender, MouseEventArgs e)
    {
        if (!startPoint.HasValue)
            return;
    
        if (endPoint.HasValue)
            ControlPaint.DrawReversibleLine(startPoint.Value, endPoint.Value, Color.White);
    
        endPoint = PointToScreen(e.Location);
        ControlPaint.DrawReversibleLine(startPoint.Value, endPoint.Value, Color.White);
    }
    
    private void Form_MouseUp(object sender, MouseEventArgs e)
    {
        startPoint = null;
        endPoint = null;
    }
