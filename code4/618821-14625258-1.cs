    private void validateTextBoxes()
    {
        foreach (Control c in c.Controls)
        {
            TextBox tb = c as TextBox;
            if (tb != null)
            {
                // No need to fire leave event 
                //just call ValidateTextBox with our textbox
                ValidateTextBox(tb);
            }
        }
    }
