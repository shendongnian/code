    TextRange range = new TextRange(RichTextBox.Selection.Start, RichTextBox.Selection.End);
    TextDecorationCollection tdc = (TextDecorationCollection)RichTextBox.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
    if (!tdc.Equals(TextDecorations.Strikethrough))
    {
        tdc = TextDecorations.Strikethrough;
    }
    range.ApplyPropertyValue(Inline.TextDecorationsProperty, tdc);
