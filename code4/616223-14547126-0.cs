    private void year_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        if (this.yearInfo == null)
        {
            return;
        }
        Point position = Mouse.GetPosition(this.mapView); //mapView is the name of my canvas
        this.yearInfo.Margin = 
             new Thickness(0, 0, position.X - this.yearInfo.ActualWidth / 2.0, 45);
    }
