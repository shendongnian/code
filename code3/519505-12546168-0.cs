    if (Orientation == Orientation.Horizontal)
    {
        double totalWidth = availableSize.Width;
        if (!double.IsNaN(ItemWidth) && !double.IsInfinity(ItemWidth) && ItemWidth > 0)
        {
            var itemsPerRow = (int)(totalWidth / ItemWidth);
            if (itemsPerRow > 0)
            {
                ItemWidth = totalWidth / itemsPerRow;
            }
        }
    }
