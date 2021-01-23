    // Respond to the left mouse button down event by initiating the hit test.
    private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Retrieve the coordinate of the mouse position.
        Point pt = e.GetPosition((UIElement)sender);
        // Perform the hit test against a given portion of the visual object tree.
        HitTestResult result = VisualTreeHelper.HitTest(myCanvas, pt);
        if (result != null)
        {
            // Perform action on hit visual object.
        } 
    }
