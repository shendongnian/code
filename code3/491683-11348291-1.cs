    private void resetPopup()
    {
       // Update position
       // http://stackoverflow.com/a/2466030/865883
       var offset = toolbar_popup.HorizontalOffset;
       toolbar_popup.HorizontalOffset = offset + 1;
       toolbar_popup.HorizontalOffset = offset;
    
       // Resizing
       toolbar_popup.Width = Player.ActualWidth;
       toolbar_popup.PlacementRectangle = new Rect(0, host.ActualHeight, 0, 0);
       toolbar_popup.Placement = System.Windows.Controls.Primitives.PlacementMode.Top;
    }
    private void Window_LocationChanged(object sender, EventArgs e)
    { resetPopup(); }
    
    private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
    { resetPopup(); }
