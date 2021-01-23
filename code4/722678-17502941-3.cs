Code behind
    // using ContentRendered event
    private void Window_ContentRendered(object sender, EventArgs e)
    {
        SolidColorBrush MyBrush = Brushes.Aquamarine;
        // Set the value
        Application.Current.Resources["DynamicBG"] = MyBrush;         
    }
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        SolidColorBrush MyBrush = Brushes.CadetBlue;
        // Set the value
        Application.Current.Resources["DynamicBG"] = MyBrush;
    }
