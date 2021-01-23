    private string previousText = string.Empty;
    private bool processing = false;
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        // If we're already messing around with the text, don't start again.
        if (processing)
            return;
        processing = true;
        // The current textbox text
        string newText = textBox1.Text;
        // What was there before, minus one character.
        string previousLessOne = previousText == string.Empty ? string.Empty : previousText.Substring(0, previousText.Length - 1);
        // Get where the user is, minus any preceding dashes
        int caret = textBox1.SelectionStart - (textBox1.Text.Substring(0, textBox1.SelectionStart).Count(ch => ch == '-'));
        // If the user has done anything other than delete the last character, ensure dashes are placed in the correct position.
        if (newText.Length > 0 && newText != previousLessOne)
        {
            textBox1.Text = string.Empty;
            newText = newText.Replace("-", "");
            for (int i = 0; i < newText.Length; i += 5)
            {
                int length = Math.Min(newText.Length - i, 5);
                textBox1.Text += newText.Substring(i, length);
                    
                if (length == 5)
                    textBox1.Text += '-';
            }
        }
        // Put the user back where they were, adjusting for dashes.
        textBox1.SelectionStart = caret + (caret / 5);
        previousText = textBox1.Text;
        processing = false;
    }
