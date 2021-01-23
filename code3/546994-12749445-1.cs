    private void OnLeftButtonClick( object sender, RoutedEventArgs e )
    {
        MoveCallout( LeftButton );
        e.Handled = true;
    }
    
    
    private void OnRightButtonClick( object sender, RoutedEventArgs e )
    {
        MoveCallout( RightButton );
        e.Handled = true;
    }
    
    private void MoveCallout( FrameworkElement element )
    {
        // find the position of the element to anchor against relative to the root object
        Point point = element.TransformToAncestor( LayoutRoot ).Transform( new Point( 0, 0 ) );
        // take into account the width of the anchor element
        double x = point.X + element.ActualWidth;
        // take into account the height of the anchor element and the callout
        // add a little wiggle room as well
        double y = point.Y - element.ActualHeight - MyCallout.ActualHeight - 10;
        MyCallout.Content = element.Name;
        // Move the callout to the new coordinates
        MyCallout.RenderTransform = new TranslateTransform( x, y );
    }
