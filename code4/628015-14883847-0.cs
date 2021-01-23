    private static void Shortcut_KeyDown(object sender, KeyEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (e.Control && e.KeyCode == Keys.A)
        {
            textBox.SelectAll();
            e.SuppressKeyPress = true;
        }
        if (e.Control && e.KeyCode == Keys.C)
        {
            textBox.Copy();
            e.SuppressKeyPress = true;
        }
        if (e.Control && e.KeyCode == Keys.V)
        {
            textBox.Text = Clipboard.GetText();
            e.SuppressKeyPress = true;
        }
    }
