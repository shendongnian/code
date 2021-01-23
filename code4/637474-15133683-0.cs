    // Holds a value determining if this is the first time the box has been clicked
    // So that the text value is not always wiped out.
    bool hasBeenClicked = false;
    
    private void TextBox_Focus(object sender, RoutedEventArgs e)
    {
        if (!hasBeenClicked)
        {
            TextBox box = sender as TextBox;
            box.Text = String.Empty;
            hasBeenClicked = true;
        }
    }
