    public static void HighlightSyntax(RichTextBox richTextBox, Regex yourRegex, Color someColor)
    {
        richTextBox.BeginUpdate();
        int selPos = richTextBox.SelectionStart;
        richTextBox.SelectAll();
        richTextBox.SelectionColor = normTextColor;
        richTextBox.Select(selPos, 0);
        // For each match from the regex, highlight the word.
        foreach (Match keyWordMatch in yourRegex.Matches(richTextBox.Text))
        {
            richTextBox.Select(keyWordMatch.Index, keyWordMatch.Length);
            richTextBox.SelectionColor = someColor;
            richTextBox.Select(selPos, 0);
            richTextBox.SelectionColor = normTextColor;
        }
        richTextBox.EndUpdate();
    }
