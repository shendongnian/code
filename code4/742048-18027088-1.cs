    private void txtResults_KeyDown(object sender, KeyEventArgs e)
    {
        string[] words = ((TextBox)sender).Text.Split(' ');
        string s = sampleWord.Text = words[words.Length - 1];
        if (e.KeyCode == Keys.OemPeriod)
        {
            ShowPopUpList(s);
            lst.SelectedIndex = 0;
        }
        else if (lst.Visible && e.KeyCode == Keys.Up)
        {
            // manipulate the selection on the listbox (move up)
            if (lst.SelectedIndex > 0) 
                lst.SelectedIndex -= 1;
            
            // eat the keypress so it textbox doesn't get it and move the cursor
            e.Handled = true; 
        }
        else if (lst.Visible && e.KeyCode == Keys.Down)
        {
            // manipulate the selection on the listbox (move down)
            if (lst.SelectedIndex < lst.Items.Count - 1) 
                lst.SelectedIndex += 1;
            // eat the keypress so it textbox doesn't get it and move the cursor
            e.Handled = true;
        }
        else if (lst.Visible && e.KeyCode == Keys.Enter)
        {
            // insert current list box selection into text box and hide the list
            txtResults.Text += lst.SelectedItem;
            txtResults.SelectionStart = txtResults.Text.Length;
            lst.Hide();
            // eat the keypress to prevent the textbox (and the form) from acting on it
            e.SuppressKeyPress = true;
            e.Handled = true;
        }
        else
        {
            lst.Hide();
        }
    }
