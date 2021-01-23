    if (textBoxEntry.Text.Length <= 1)
    {
        textBoxMasked.Text = textBoxEntry.Text;
    }
    else
    {
        string lastChar = textBoxEntry.Text.Substring(textBoxEntry.Text.Length-1, 1);
        textBoxMasked.Text = lastChar.PadLeft(textBoxEntry.Text.Length, '*');
    }
