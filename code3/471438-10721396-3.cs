    // as we don't have eventargs here exposing the current mouse position we use the
    // win32 API to get the current mouse position
    Win32.POINT p;
    if (!Win32.GetCursorPos(out p))
    {
        return;
    }
    
    //this is the point on the screen
    Point point = new Point(p.X, p.Y);
    
    //get position relative to scrollViewerControl
    Point controlPoint = _scrollViewerControl.PointFromScreen(point);
    
    if (controlPoint.Y < 10 && -10 < controlPoint.Y)
    {
        _scrollViewerControl.LineUp();
    }
    else if (controlPoint.Y > _scrollViewerControl.ViewportHeight - 10 && _scrollViewerControl.ViewportHeight + 10 > controlPoint.Y)
    {
        _scrollViewerControl.LineDown();
    }
    
    if (controlPoint.X < 10 && -10 < controlPoint.X)
    {
        _scrollViewerControl.LineLeft();
    }
    else if (controlPoint.X > _scrollViewerControl.ViewportWidth - 10 && _scrollViewerControl.ViewportWidth + 10 > controlPoint.X)
    {
        _scrollViewerControl.LineRight();
    }
