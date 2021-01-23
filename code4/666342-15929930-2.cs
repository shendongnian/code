    private void pseudo_GotFocus(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("pseudo"); isPseudoFocused = true; isPasswordFocused = false;
    }
    private void password_GotFocus(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("password"); isPseudoFocused = false; isPasswordFocused = true;
    }
 
