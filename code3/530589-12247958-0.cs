    private void listBox_KeyDown(object sender, KeyEventArgs e)
    {
        // Check that the button pressed is V, that Control is also pressed and that the clipboard contains text.
        if ((e.KeyCode == Keys.V) && e.Control && Clipboard.ContainsText())
        {
            // Get text from clipboard and separate it.
            string text = Clipboard.GetText();
            string[] textLines = text.Split(
                new string[] { Environment.NewLine }, 
                StringSplitOptions.RemoveEmptyEntries); // or don't
            // Add lines to listBox items.
            listBox.Items.AddRange(textLines);
            // Mark event as handled.
            e.Handled = true;
        }
    }
