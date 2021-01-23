    private void OnMouseLeftButtonDown( object sender, MouseButtonEventArgs e )
    {
        stackPanel.Visibility = stackPanel.Visibility == Visibility.Visible
                                        ? Visibility.Collapsed
                                        : Visibility.Visible;
    
        e.Handled = true;
    }
