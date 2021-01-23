    private void TitleBorder_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
        StartMousePosition = e.GetPosition( canvas );
        TitleBorder.CaptureMouse();
    }
    private void TitleBorder_MouseLeftButtonUp( object sender, MouseButtonEventArgs e ) {
        if ( TitleBorder.IsMouseCaptured ) {
            Point mousePosition = e.GetPosition( canvas );
            Canvas.SetLeft( this, Canvas.GetLeft( this ) + mousePosition.X - StartMousePosition.X );
            Canvas.SetTop ( this, Canvas.GetTop ( this ) + mousePosition.Y - StartMousePosition.Y );
            canvas.ReleaseMouseCapture();
        }
    }
    private void TitleBorder_MouseMove( object sender, MouseEventArgs e ) {
        if ( TitleBorder.IsMouseCaptured && e.LeftButton == MouseButtonState.Pressed ) {
            Point mousePosition = e.GetPosition( canvas );
            // Compute the new Left & Top coordinates of the control
            Canvas.SetLeft( this, Canvas.GetLeft( this ) + mousePosition.X - StartMousePosition.X );
            Canvas.SetTop ( this, Canvas.GetTop ( this ) + mousePosition.Y - StartMousePosition.Y );
            StartMousePosition = mousePosition;
        }
    }
