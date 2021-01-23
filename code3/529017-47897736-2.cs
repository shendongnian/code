    public double GetTextLineVisualYPosition(TextLine textLine, VisualYPosition yPositionMode) {
        if (textLine == null)
            throw new ArgumentNullException("textLine");
        double pos = VisualTop;
        foreach (TextLine tl in TextLines) {
            if (tl == textLine) {
                switch (yPositionMode) {
                case VisualYPosition.LineTop:
                    return pos;
                case VisualYPosition.LineMiddle:
                    return pos + tl.Height / 2 * textView.LineSpacing;
                case VisualYPosition.LineBottom:
                    return pos + tl.Height * textView.LineSpacing;
                case VisualYPosition.TextTop:
                    return pos + tl.Baseline - textView.DefaultBaseline;
                case VisualYPosition.TextBottom:
                    return pos + tl.Baseline - textView.DefaultBaseline + textView.DefaultLineHeight;
                case VisualYPosition.TextMiddle:
                    return pos + tl.Baseline - textView.DefaultBaseline + textView.DefaultLineHeight / 2;
                case VisualYPosition.Baseline:
                    return pos + tl.Baseline;
                default:
                    throw new ArgumentException("Invalid yPositionMode:" + yPositionMode);
                }
            }
            else {
                pos += tl.Height * textView.LineSpacing;
            }
        }
        throw new ArgumentException("textLine is not a line in this VisualLine");
    }
