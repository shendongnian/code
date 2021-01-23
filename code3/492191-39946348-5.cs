    if (Capture.Length == 0 || Capture.Index == Record.Index || Record.Value[Capture.Index - Record.Index - 1] != '\"')
    {
        // No need to unescape/undouble quotes if the value is empty, the value starts
        // at the beginning of the record, or the character before the value is not a
        // quote (not a quoted value)
        Console.WriteLine(Capture.Value);
    }
    else
    {
        // The character preceding this value is a quote
        // so we need to unescape/undouble any embedded quotes
        Console.WriteLine(Capture.Value.Replace("\"\"", "\""));
    }
