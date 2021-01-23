    // the regex code   
    private Control keyb = null;
    private void EditProdPriceEx_GotFocus(object sender, RoutedEventArgs e)
    {
        string AllowedChars = "[^0-9,]";
        if (Regex.IsMatch(EditProdPriceEx.Text, AllowedChars))
        {
            keyb = (Control)sender;
        }
    }
