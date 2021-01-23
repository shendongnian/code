    private Rectangle _hotspot = new Rectangle(20, 30, 10, 10);
    protected override void OnMouseMove(MouseEventArgs mouseEvent) 
    { 
        Point mouse = new Point(mouseEvent.X, mouseEvent.Y);
        if(_hotspot.Contains(mouse))
        {
            // respond to the mouse being in the hotspot
        }
    }
