    bool IsInComment(int line, int column)
    {
        IHighlighter highlighter = textEditor.TextArea.GetService(typeof(IHighlighter)) as IHighlighter;
        if (highlighter == null)
            return false;
        int off = textEditor.Document.GetOffset(line, column);
        HighlightedLine result = highlighter.HighlightLine(document.GetLineByNumber(line));
        return result.Sections.Any(s => s.Offset <= off && s.Offset+s.Length >= off && s.Color.Name == "Comment");
    }
