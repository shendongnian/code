    public static void InsertText(RichTextBox richText, int line, string text) {
        // Find the position at the end of the specified line.
        var documentStart = richText.Document.ContentStart;
        var lineEnd = documentStart.GetLineStartPosition(line + 1)
                          .GetPositionAtOffset(1, LogicalDirection.Backward);
        
        // Insert the text there.
        lineEnd.InsertTextInRun(text);
    }
