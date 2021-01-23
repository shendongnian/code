    void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        foreach (var item in MyStackPanel.Children.OfType<Windows.UI.Xaml.Shapes.Rectangle>())
        {
            // the box around the child
            var _ItemBounds = item.TransformToVisual(null).TransformBounds(new Rect(0, 0, item.ActualWidth, item.ActualHeight));
            // the box around the screen 
            var _Intersection = Window.Current.Bounds;
            _Intersection.Intersect(_ItemBounds);
            if (_Intersection.Equals(_ItemBounds))
                // full
                item.Fill = new SolidColorBrush(Windows.UI.Colors.Green);
            else if (_Intersection.Equals(Rect.Empty))
                // none
                item.Fill = new SolidColorBrush(Windows.UI.Colors.Red);
            else
                // partial
                item.Fill = new SolidColorBrush(Windows.UI.Colors.Orange);
        }
    }
