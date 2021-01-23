    private void Grid_MouseLeftButtonDown( object sender, MouseButtonEventArgs e ) {
        CurrentMousePosition = e.GetPosition( Parent as Window );
        TitleBorder.CaptureMouse();
    }
    
    private void Grid_MouseLeftButtonUp( object sender, MouseButtonEventArgs e ) {
        if ( TitleBorder.IsMouseCaptured ) {
            TitleBorder.ReleaseMouseCapture();
        }
    }
    
    private void Grid_MouseMove( object sender, MouseEventArgs e ) {
        Vector diff = e.GetPosition( Parent as Window ) - CurrentMousePosition;
        if ( TitleBorder.IsMouseCaptured ) {
            ( RenderTransform as TranslateTransform ).X = diff.X;
            ( RenderTransform as TranslateTransform ).Y = diff.Y;
        }
    }
