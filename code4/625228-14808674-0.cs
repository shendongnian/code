    private void editMenuItemOpened(object sender, EventArgs e)
    {
        copyMenuItem.Enabled = cutMenuItem.Enabled = textBox1.SelectionLength > 0;
        pasteMenuItem.Enabled = Clipboard.ContainsText();
    }
