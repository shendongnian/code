    private const char ENTER_KEY = (char)13;
    private const char CNTRL_V = (char)22;
    
    private void Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox caller = sender as TextBox;
            char ch = e.KeyChar;
            int position = caller.SelectionStart;
            if (ch >= 32 && ch <= 126) //acceptable password symbol
            {
                int len = caller.SelectionLength;
                if (caller.SelectionLength > 0) //Handles inserting when text is selected (removing selected characters)
                {
                    for (int i = caller.SelectionStart; i < caller.SelectionStart + caller.SelectionLength; i++)
                        _SecurePassword.RemoveAt(caller.SelectionStart);
                    caller.Text = caller.Text.Remove(caller.SelectionStart, caller.SelectionLength);
                }
                _SecurePassword.InsertAt(position, ch);
                caller.Text = caller.Text + '*'; //generate a * so the user knows how many characters they've entered
                caller.SelectionStart = position + 1;
            }
            else //handle other symbol
            {
                switch (ch)
                {
                    case CNTRL_V:
                        Password_PasteClicked(null, null); //handle paste event
                        break;
                    case ENTER_KEY:
                        SaveAndCloseButton_Click(null, null); //handle enter .. if you want to.
                        break;
                  //add events for any special characters here
                }     
            }
                    
