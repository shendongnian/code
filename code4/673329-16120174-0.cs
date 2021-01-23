    private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
    {
        // Disable Undo if CanUndo property returns false
        if (textBox1.CanUndo)
        {
            contextMenuStrip1.Items["Undo"].Enabled = true;
        }
        else
        {
            contextMenuStrip1.Items["Undo"].Enabled = false;
        }
 
    // Disable Cut, Copy and Delete if any text is not selected in TextBox
    if (textBox1.SelectedText.Length == 0)
    {
        contextMenuStrip1.Items["Cut"].Enabled = false;
        contextMenuStrip1.Items["Copy"].Enabled = false;
        contextMenuStrip1.Items["Delete"].Enabled = false;
    }
    else
    {
        contextMenuStrip1.Items["Cut"].Enabled = true;
        contextMenuStrip1.Items["Copy"].Enabled = true;
        contextMenuStrip1.Items["Delete"].Enabled = true;
    }
 
    // Disable Paste if Clipboard does not contains text
    if (Clipboard.ContainsText())
    {
        contextMenuStrip1.Items["Paste"].Enabled = true;
    }
    else
    {
        contextMenuStrip1.Items["Paste"].Enabled = false;
    }
 
    // Disable Select All if TextBox is blank
    if (textBox1.Text.Length == 0)
    {
        contextMenuStrip1.Items["SelectAll"].Enabled = false;
    }
    else
    {
        contextMenuStrip1.Items["SelectAll"].Enabled = true;
    }
