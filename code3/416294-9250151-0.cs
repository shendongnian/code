    /// <summary>
    /// Searches the descendants of the given element, looking for a scrollbar
    /// with the given orientation.
    /// </summary>
    private static ScrollBar GetScrollBar(FrameworkElement fe, Orientation orientation)
    {
      return fe.Descendants()
                .OfType<ScrollBar>()
                .Where(s => s.Orientation == orientation)
                .SingleOrDefault();
     
    }
