    public void SetRichTextBoxText(string[] lines)
    {
        if(!richTextBox1.InvokeRequired)
        {
            richTextBox1.Lines = lines;
        }
        else
        {
            var callback = new Action<string[]>(SetRichTextBoxText);
            Invoke(callback, lines);
        }
    }
