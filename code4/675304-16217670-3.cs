    public void OnScrollChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            //We have to check if the values are 0.0 because they are both set to this when the scrollviewer loads
            if ((scrollViewer.ScrollableHeight <= scrollViewer.VerticalOffset)
                && (scrollViewer.ScrollableHeight != 0.0 && scrollViewer.VerticalOffset != 0.0))
            {
                //The ScrollBar is at the bottom, load more results.
            }
        }
