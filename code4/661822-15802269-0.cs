    // so you have colour (set via the Designer)
    richTextBox.Enabled = true;
    
    // so users cannot change the contents (set via the Designer)
    richTextBox.ReadOnly = true;
    
    // allow users to select the text, but override what they do, IF they select the text (set via the Designer)
    richTextBox.SelectionChanged += new System.EventHandler(this.richTextBox_SelectionChanged);
    
    // If the user selects text, then de-select it
    private void richTextBox_SelectionChanged(object sender, EventArgs e)
    {
        // Move the cursor to the end
        if (this.richTextBox.SelectionStart != this.richTextBox.TextLength)
        {
            this.richTextBox.SelectionStart = this.richTextBox.TextLength;
        }
    }
