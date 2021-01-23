        private void TextBox1_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Background = new SolidColorBrush(Colors.Transparent);
            tb.BorderBrush = new SolidColorBrush(Colors.Transparent);
            tb.SelectionBackground = new SolidColorBrush(Colors.Transparent);
        }
        private void TextBox1_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            tb.Background = new SolidColorBrush(Colors.Transparent);
            tb.BorderBrush = new SolidColorBrush(Colors.Transparent);
            tb.SelectionBackground = new SolidColorBrush(Colors.Transparent);
        }
