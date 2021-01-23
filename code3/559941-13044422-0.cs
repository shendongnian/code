    /// <summary>
    /// Get the first child of type T in the visual tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns>the first child of type T in the visual tree, or null if no such element exists</returns>
    public static T GetChildOfType<T>(this DependencyObject source) where T : DependencyObject
    {
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(source); i++)
        {
            var child = VisualTreeHelper.GetChild(source, i);
            if (child != null && child.GetType() == typeof(T))
                return child as T;
        }
        for (var i = 0; i < VisualTreeHelper.GetChildrenCount(source); i++)
        {
            var child = VisualTreeHelper.GetChild(source, i);
            var t = child.GetChildOfType<T>();
            if (t != null) return t;
        }
        return null;
    }
