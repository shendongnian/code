    private void click(object sender, RoutedEventArgs e)
    {
        var button = sender as Button;
        var parent = button.Parent as FrameworkElement;
        var textBox = parent.FindName("textbox1") as TextBox;
        button.Content = textBox.Text;
    }
