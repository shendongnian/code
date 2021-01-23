    private void Button_Click(object sender, RoutedEventArgs e)
    {
       var button = sender as Button;
       var ttv = button.TransformToVisual(Window.Current.Content);
       Point screenCoords = ttv.TransformPoint(new Point(0, 0));
    }
