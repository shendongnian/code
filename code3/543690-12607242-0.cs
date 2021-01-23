    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        // Check for the flag being set in the KeyDown event.
        if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^+^\-^\/^\*^\(^\)]"))
        {
            // Stop the character from being entered into the control since it is illegal.
            e.Handled = true;
        }
    }
