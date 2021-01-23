    //...
    //register event handler
    yourTextBox.KeyDown += new KeyEventHandler(yourTextBox_KeyDown);
    //...
    
    //the keydown event
    public void yourTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(yourTextBox.Text,"<enter a regular expression here>"))
             e.Handled = true;
        else e.Handled = false;
    }
