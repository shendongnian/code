    private void ButtonClick(object sender, RoutedEventArgs e)
    {
        this.Menu.Visibility = this.Menu.Visibility == Visibility.Visible
                                    ? Visibility.Collapsed
                                    : Visibility.Visible;
    }
