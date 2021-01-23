    public TextLine GetTextLineByVisualYPosition(double visualTop) {
        const double epsilon = 0.0001;
        double pos = this.VisualTop;
        foreach (TextLine tl in TextLines) {
            pos += tl.Height * textView.LineSpacing;
            if (visualTop + epsilon < pos)
                return tl;
        }
        return TextLines[TextLines.Count - 1];
    }
