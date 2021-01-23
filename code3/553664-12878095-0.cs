    static T FindVisualChild<T>(Visual parent) where T : Visual
    {
        T child = default(T);
        int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
        for (int i = 0; i < numVisuals; i++)
        {
            var visual = (Visual)VisualTreeHelper.GetChild(parent, i);
            
            child = visual as T;
            if (child == null)
                child = FindVisualChild<T>(visual);
            if (child != null)
                break;
        }
        return child;
    }
