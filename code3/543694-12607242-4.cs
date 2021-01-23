    textBox1.KeyPress += new KeyPressEventHandler(textBox1_KeyPress);
    private void textBox1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        // Check for a naughty character in the KeyDown event.
        if (System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar.ToString(), @"[^0-9^+^\-^\/^\*^\(^\)]"))
        {
            // Stop the character from being entered into the control since it is illegal.
            e.Handled = true;
        }
    }
