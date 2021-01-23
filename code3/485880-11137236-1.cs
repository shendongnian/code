    private void PauseButton_Checked(object sender, RoutedEventArgs e)
    {
        (sender as ToggleButton).Background = Brushes.White;
        PauseIcon.Fill = Brushes.Black;
    }
    private void PauseButton_Unchecked(object sender, RoutedEventArgs e)
    {
        (sender as ToggleButton).Background = Brushes.Black;
        PauseIcon.Fill = Brushes.White;
    }
