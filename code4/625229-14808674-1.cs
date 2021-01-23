    private void editMenuItemOpened(object sender, EventArgs e)
    {
        //enable copy and cut only if some text is selected
        copyMenuItem.Enabled = cutMenuItem.Enabled = textBox1.SelectionLength > 0;
        //enable paste only if there's some text in the clipboard to paste
        pasteMenuItem.Enabled = Clipboard.ContainsText();
    }
