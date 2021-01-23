    // Returns a one-based line number and column of the selection start
    private static Tuple<int, int> GetPosition(TextBox text)
    {
        // Selection start always reports the position as though newlines are one character
        string contents = text.Text.Replace(Environment.NewLine, "\n");
        int i, pos = 0, line = 1;
        // Loop through all the lines up to the selection start
        while ((i = contents.IndexOf('\n', pos, text.SelectionStart - pos)) != -1)
        {
            pos = i + 1;
            line++;
        }
        // Column is the remaining characters
        int column = text.SelectionStart - pos + 1;
        return Tuple.Create(line, column);
    }
