    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Button button = sender as Button;
        int index = (int)button.Tag;
        // get page by zero-based index
        ...
    }
