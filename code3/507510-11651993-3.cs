    Geometry clip = new RectangleGeometry(new Rect(0,0,this.ActualWidth, this.ActualHeight));
    
    dc.PushClip(clip);
    
    dc.DrawLine(new Pen(Brushes.Red, 2), new Point(0, 0), new Point(this.EndX, 100));
    dc.DrawLine(new Pen(Brushes.Green, 3), new Point(200, 10), new Point(10, 300));
    
    dc.Pop();
