    private Point origin;
    private void SelectedLineOnMouseLeftButtonDown(object sender, MouseButtonEventArgs e) 
    {
        e.Handled = true;
        Line line = (Line) sender;
        line.CaptureMouse();
        startPoint = new Point(line.X1, line.Y1);
        endPoint = new Point(line.X2, line.Y2);
        origin = e.GetPosition(line);
        base.OnMouseLeftButtonDown(e);
    }
    private void SelectedLineOnMouseMove(object sender, MouseEventArgs e) 
    {
        base.OnMouseMove(e);
        Line line = (Line) sender;
        if (e.MouseDevice.LeftButton == MouseButtonState.Pressed) 
        {
            Point position = e.GetPosition(this);
            e.Handled = true;
            double horizontalDelta = position.X - origin.X;
            double verticalDelta = position.Y - origin.Y;
            line.X1 = startPoint.X + horizontalDelta;
            line.X2 = endPoint.X + horizontalDelta;
            line.Y1 = startPoint.Y + verticalDelta;
            line.Y2 = endPoint.Y + verticalDelta;
            InvalidateArrange();
        }
        else 
        {
            line.ReleaseMouseCapture();
        }
    }
    private void SelectedLineOnMouseLeftButtonUp(object sender, MouseButtonEventArgs e) 
    {
        Line line = (Line) sender;
        line.ReleaseMouseCapture();
        e.Handled = true;
    
        base.OnMouseLeftButtonUp(e);
    }
