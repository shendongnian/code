    private void boldToolStripButton_Click(object sender, EventArgs e)
    {
        ToggleFontStyle(FontStyle.Bold);
        boldToolStripButton.Checked = !boldToolStripButton.Checked;
    }
    private void ToggleFontStyle(FontStyle style)
    {
        int selStart = richTextBox.SelectionStart;
        int selLength = richTextBox.SelectionLength;
        int selEnd = selStart + selLength;
        if (selLength == 0) {
            return;
        }
        Font selFont = richTextBox.SelectionFont;
        if (selFont == null) {
            richTextBox.Select(selStart, 1);
            selFont = richTextBox.SelectionFont;
            if (selFont == null) {
                return;
            }
        }
        bool set = (selFont.Style & style) == FontStyle.Regular;
        for (int from = selStart, len = 1; from < selEnd; from += len) {
            richTextBox.Select(from, 1);
            Font refFont = richTextBox.SelectionFont;
            for (int i = from + 1; i < selEnd; i++, len++) {
                richTextBox.Select(i, 1);
                if (!refFont.Equals(richTextBox.SelectionFont))
                    break;
            }
            richTextBox.Select(from, len);
            if (set) {
                richTextBox.SelectionFont = new Font(refFont, refFont.Style | style);
            } else {
                richTextBox.SelectionFont = new Font(refFont, refFont.Style & ~style);
            }
        }
        // Restore the original selection
        richTextBox.Select(selStart, selLength);
    }
