    private void ShowPasswordCharsCheckBox_Checked(object sender, RoutedEventArgs e)
    {
        MyPasswordBox.Visibility = System.Windows.Visibility.Collapsed;
        MyTextBox.Visibility = System.Windows.Visibility.Visible;
        MyTextBox.Focus();
    }
    private void ShowPasswordCharsCheckBox_Unchecked(object sender, RoutedEventArgs e)
    {
        MyPasswordBox.Visibility = System.Windows.Visibility.Visible;
        MyTextBox.Visibility = System.Windows.Visibility.Collapsed;
        MyPasswordBox.Focus();
    }
