    if (Orientation == Orientation.Horizontal)
    {
        double supostWidth = 0.0;
        foreach (UIElement el in Children)
        {
           el.Measure(availableSize);
           Size next = el.DesiredSize;
           if (!(Double.IsInfinity(next.Width) || Double.IsNaN(next.Width)))
           {
                supostWidth = Math.Max(next.Width, supostWidth);
           }
        }
        double totalWidth = availableSize.Width;
        if (!double.IsNaN(supostWidth) && !double.IsInfinity(supostWidth) && supostWidth > 0)
        {
            var itemsPerRow = (int)(totalWidth / supostWidth);
            if (itemsPerRow > 0)
            {
                ItemWidth = totalWidth / itemsPerRow;
            }
        }
    }
