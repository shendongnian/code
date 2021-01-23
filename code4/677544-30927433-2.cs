    public static T GetTemplatedParent<T>(this FrameworkElement o)
        where T : DependencyObject
    {
        DependencyObject child = o, parent = null;
        while (child != null && (parent = LogicalTreeHelper.GetParent(child)) == null)
        {
            child = VisualTreeHelper.GetParent(child);
        }
        FrameworkElement frameworkParent = parent as FrameworkElement;
        return frameworkParent != null ? frameworkParent.TemplatedParent as T : null;
    }
