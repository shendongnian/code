    public static IEnumerable<T> RecurseChildren<T>(DependencyObject root) where T : UIElement
    {
        if (root is T)
        {
            yield return root as T;
        }
        if (root != null)
        {
            var count = VisualTreeHelper.GetChildrenCount(root);
               
            for (var idx = 0; idx < count; idx++)
            {
                foreach (var child in RecurseChildren<T>(VisualTreeHelper.GetChild(root, idx)))
                {
                    yield return child;
                }
            }
        }
    }
