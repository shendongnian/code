     void AccountsListBox_Click (object sender, EventArgs args) 
     {
        if (AccountsListBox.SelectedIndex < 0)
            return;
    
        if (!string.IsNullOrEmpty(TextBoxName.Text) && !string.IsNullOrEmpty(TextBoxPass.Text)) 
            return; // stop processing if they have some data
        // otherwise get acccount:password, 
        // split it into acc and pass and write them to TextBoxes
        string value = AccountsListBox.Items[AccountsListBox.SelectedIndex];
        string[] values = value.Split(':');
        if (values.Length != 2)
            return;  // wrong format        
        var acc   = values[0];
        var pass  = values[1];
    
        TextBoxName.Text = acc;
        TextBoxPass.Text = pass;
    }
