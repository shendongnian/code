    private void Button_Click(object sender, RoutedEventArgs e)
    {
        comboBox1.Visibility = Windows.UI.Xaml.Visibility.Visible;
        Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => comboBox1.IsDropDownOpen = true);
    }
