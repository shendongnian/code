    private static TextPointer GetTextPointAt(TextPointer from, int pos)
      {
        TextPointer ret = from;
        int i = 0;
        while ((i < pos) && (ret != null))
        {
            if ((ret.GetPointerContext(LogicalDirection.Backward) == TextPointerContext.Text) || (ret.GetPointerContext(LogicalDirection.Backward) == TextPointerContext.None))
                i++;
            if (ret.GetPositionAtOffset(1, LogicalDirection.Forward) == null)
                return ret;
            ret = ret.GetPositionAtOffset(1, LogicalDirection.Forward);
        }
        return ret;
     }
     internal string Select(RichTextBox rtb, int offset, int length, Color color)
     {
        // Get text selection:
        TextSelection textRange = rtb.Selection;
        // Get text starting point:
        TextPointer start = rtb.Document.ContentStart;
        // Get begin and end requested:
        TextPointer startPos = GetTextPointAt(start, offset);
        TextPointer endPos = GetTextPointAt(start, offset + length);
        // New selection of text:
        textRange.Select(startPos, endPos);
        // Apply property to the selection:
        textRange.ApplyPropertyValue(TextElement.BackgroundProperty, new SolidColorBrush(color));
        // Return selection text:
        return rtb.Selection.Text;
     }
