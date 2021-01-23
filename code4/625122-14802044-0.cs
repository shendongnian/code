    static FrameworkElement GetVisualDescendantByName(DependencyObject control, string name)
    {
        // Recurse
        FrameworkElement el = null;
        int nChildren = VisualTreeHelper.GetChildrenCount(control);
        for (int i = 0; i < nChildren; i++)
        {
            var child = VisualTreeHelper.GetChild(control, i);
            el = GetVisualDescendantByName(child, name);
            if (el != null)
                return el;
        }
        // See if control is a match
        if (control is FrameworkElement)
        {
            el = control as FrameworkElement;
            if (el.Name == name)
                return control as FrameworkElemdent;
        }
        return null;
    }
