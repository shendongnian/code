    private void ColorInlineAtIndex(InlineCollection inlines, int index, Brush brush)
    {
        if (index <= inlines.Count - 1)
        {
              inlines.ElementAt(index).Foreground = brush;
        }
    }
