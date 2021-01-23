    protected override Size MeasureOverride(Size availableSize)
    {
        // You still measure the children.  You just don't use them when determining the size of the panel.
        foreach(FrameworkElement childElement in this.Children)
        {
            if(childElement.Visibility != Visibility.Collapsed)
                childElement.Measure(availableSize);
        }
        return new Size(
            Double.IsPositiveInfinity(availableSize.Width)  ? 0 : availableSize.Width,
            Double.IsPositiveInfinity(availableSize.Height) ? 0 : availableSize.Height);
    }
