    private static List<string> GetLines(this TextBox textBox)
    {
        List<string> lines = new List<string>();
    
        // lineCount may be -1 if TextBox layout info is not up-to-date.
        int lineCount = textBox.LineCount;
    
        for (int line = 0; line < lineCount; line++)
        {
            lines.Add(textBox.GetLineText(line));
        }
        return lines;
    }
