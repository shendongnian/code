    public static WpfPageTransitions.PageTransition FindPageControl(DependencyObject child)
    {
        DependencyObject parent= VisualTreeHelper.GetParent(child);
    
        if (parent == null) return null;
    
        WpfPageTransitions.PageTransition page = parent as WpfPageTransitions.PageTransition;
        if (page != null)
        {
            return page;
        }
        else
        {
            return FindPageControl(parent);
        }
    }
