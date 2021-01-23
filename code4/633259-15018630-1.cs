    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        Style style = new Style(typeof (TextBlock));
        style.Setters.Add(new Setter(TextBlock.ForegroundProperty, Brushes.Green));
        style.Setters.Add(new Setter(TextBlock.TextProperty, "Green"));
        Resources.Add(typeof (TextBlock), style);
    }
