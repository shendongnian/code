    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        CheckBox1.IsChecked = MyState.IsChecked1;
    }
    private void Window_Closed(object sender, EventArgs e)
    {
        MyState.IsChecked1 = CheckBox1.IsChecked;
    }
