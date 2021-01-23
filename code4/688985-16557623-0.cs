    static List<string> WrapText(string text, double pixels, string fontFamily, float emSize)
    {
        string[] originalLines = text.Split(new string[] { " " }, StringSplitOptions.None);
        List<string> wrappedLines = new List<string>();
        StringBuilder actualLine = new StringBuilder();
        double actualWidth = 0;
        foreach (var item in originalLines)
        {
            FormattedText formatted = new FormattedText(item, CultureInfo.CurrentCulture, System.Windows.FlowDirection.LeftToRight,
                                      new Typeface(fontFamily), emSize, Brushes.Black);
            actualLine.Append(item + " ");
            actualWidth += formatted.Width;
            if (actualWidth > pixels)
            {
                wrappedLines.Add(actualLine.ToString());
                actualLine.Clear();
                actualWidth = 0;
            }
        }
        if(actualLine.Length > 0)
            wrappedLines.Add(actualLine.ToString());
        return wrappedLines;
    }
