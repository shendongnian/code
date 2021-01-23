using System.Text.RegularExpressions;
    private void Form1_Shown(object sender, EventArgs e)
    {
        filterTextBoxContent(textBox1);
    }
    string pattern = @"[^0-9^+^\-^/^*^(^)]";
    private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if(e.KeyChar >= 32 && Regex.Match(e.KeyChar.ToString(), pattern).Success) { e.Handled = true; }
    }
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        filterTextBoxContent(textBox1);
    }
    private bool filterTextBoxContent(TextBox textBox)
    {
        string text = textBox.Text;
        MatchCollection matches = Regex.Matches(text, pattern);
        bool matched = false;
        int selectionStart = textBox.SelectionStart;
        int selectionLength = textBox.SelectionLength;
        int leftShift = 0;
        foreach (Match match in matches)
        {
            if (match.Success && match.Captures.Count > 0)
            {
                matched = true;
                Capture capture = match.Captures[0];
                int captureLength = capture.Length;
                int captureStart = capture.Index - leftShift;
                int captureEnd = captureStart + captureLength;
                int selectionEnd = selectionStart + selectionLength;
                text = text.Substring(0, captureStart) + text.Substring(captureEnd, text.Length - captureEnd);
                textBox.Text = text;
                int boundSelectionStart = selectionStart < captureStart ? -1 : (selectionStart < captureEnd ? 0 : 1);
                int boundSelectionEnd = selectionEnd < captureStart ? -1 : (selectionEnd < captureEnd ? 0 : 1);
                if (boundSelectionStart == -1)
                {
                    if (boundSelectionEnd == 0)
                    {
                        selectionLength -= selectionEnd - captureStart;
                    }
                    else if (boundSelectionEnd == 1)
                    {
                        selectionLength -= captureLength;
                    }
                }
                else if (boundSelectionStart == 0)
                {
                    if (boundSelectionEnd == 0)
                    {
                        selectionStart = captureStart;
                        selectionLength = 0;
                    }
                    else if (boundSelectionEnd == 1)
                    {
                        selectionStart = captureStart;
                        selectionLength -= captureEnd - selectionStart;
                    }
                }
                else if (boundSelectionStart == 1)
                {
                    selectionStart -= captureLength;
                }
                leftShift++;
            }
        }
        textBox.SelectionStart = selectionStart;
        textBox.SelectionLength = selectionLength;
        return matched;
    }
