    public static PageTransition FindPageControl()
    {
        DependencyObject parent= VisualTreeHelper.GetParent(this);
        if (parent == null) return null;
        PageTransition page = parent as PageTransition;
        if (page != null)
        {
            return page;
        }
        else
        {
            return FindParentWindow(parent);
        }
    }
