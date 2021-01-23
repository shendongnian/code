    private void OnTestTextBoxGotFocus(object sender, RoutedEventArgs e)
    {
        if (testTextBox.Text.Equals("Type here...", StringComparison.OrdinalIgnoreCase))
        {
            testTextBox.Text = string.Empty;
        }  
    }
    
    private void OnTestTextBoxLostFocus(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(testTextBox.Text))
        {
            testTextBox.Text = "Type here...";
        }
    }
