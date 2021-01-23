    public static T[] FindVisualChilds<T>(DependencyObject parent, Func<DependencyObject, bool> CompareDelegate)
        where T : DependencyObject
    {
        if (VisualTreeHelper.GetChildrenCount(parent) == 0) return null;
        List<T> childs = new List<T>();
        if (CompareDelegate(parent))
            childs.Add(parent as T);
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
        {
            var tmp = FindVisualChilds<T>(VisualTreeHelper.GetChild(parent, i), CompareDelegate);
            if (tmp != null)
                childs.AddRange(tmp);
        }
        return childs.ToArray();
    }
