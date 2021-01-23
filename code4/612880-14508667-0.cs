    protected override Size MeasureOverride(Size availableSize)
    {
        // just to make the code easier to read
        bool wrapping = this.TextWrapping == TextWrapping.Wrap;
        Size unboundSize = wrapping ? new Size(availableSize.Width, double.PositiveInfinity) : new Size(double.PositiveInfinity, availableSize.Height);
        string reducedText = this.Text;
        // set the text and measure it to see if it fits without alteration
        if (string.IsNullOrEmpty(reducedText)) reducedText = string.Empty;
        this.textBlock.Text = reducedText;
        Size textSize = base.MeasureOverride(unboundSize);
        while (wrapping ? textSize.Height > availableSize.Height : textSize.Width > availableSize.Width)
        {
            int prevLength = reducedText.Length;
                
            if (reducedText.Length > 0)
                reducedText = this.ReduceText(reducedText);    
                
            if (reducedText.Length == prevLength)
                break;
            this.textBlock.Text = reducedText + "...";
            textSize = base.MeasureOverride(unboundSize);
        }
        return base.MeasureOverride(availableSize);
    }
