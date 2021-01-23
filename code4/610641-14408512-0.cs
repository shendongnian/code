    Func<DependencyObject, ScrollViewer> getFirstDescendantScrollViewer = null;
    getFirstDescendantScrollViewer =
        parent =>
        {
            var c = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < c; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                var sv = child as ScrollViewer;
                if (sv != null)
                    return sv;
                sv = getFirstDescendantScrollViewer(child);
                if (sv != null)
                    return sv;
            }
            return null;
        };
    var tbsv = getFirstDescendantScrollViewer(tb);
    tbsv.ScrollToVerticalOffset(tbsv.ScrollableHeight);
