    public static PageTransition FindPageControl(DependencyObject child)
    {
        DependencyObject parent= VisualTreeHelper.GetParent(child);
        if (parent == null) return null;
        PageTransition page = parent as PageTransition;
        if (page != null)
        {
            return page;
        }
        else
        {
            return FindPageControl(parent);
        }
    }
