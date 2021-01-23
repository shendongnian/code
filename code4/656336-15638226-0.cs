    private void txtHoverWord_MouseMove(object sender, MouseEventArgs e)
    {
        if (!(sender is TextBox)) return;
        var targetTextBox = sender as TextBox;
        if (targetTextBox.TextLength < 1) return;
        var currentTextIndex = targetTextBox.GetCharIndexFromPosition(e.Location);
        var wordRegex = new Regex(@"(\w+)");
        var words = wordRegex.Matches(targetTextBox.Text);
        if (words.Count < 1) return;
        var currentWord = string.Empty;
        for (var i = words.Count - 1; i >= 0; i--)
        {
            if (words[i].Index <= currentTextIndex)
            {
                currentWord = words[i].Value;
                break;
            }
        }
        if (currentWord == string.Empty) return;
        tooltip1.SetToolTip(targetTextBox, currentWord);
    }
