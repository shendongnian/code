    public static T GetFirstVisualChild<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj != null)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                if (child != null && child is T)
                {
                    return (T)child;
                }
    
                T childItem = GetFirstVisualChild<T>(child);
                if (childItem != null) return childItem;
            }
        }
    
        return null;
    }
