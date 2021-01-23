    public static int GetLineIndex(this TextBox textbox, int line)
    {
        var text = textbox.Text;
        var thisLine = 0;
        for (var i = 0; i < text.Length; i++)
        {
            if (thisLine == line)
                return i;
    
            if (text[i] == '\n')
                ++thisLine;
        }
    
        throw new ArgumentOutOfRangeException();
    }
