        static T FindAncestor<T>(DependencyObject obj) where T : DependencyObject
        {
            var tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !(tmp is T))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return (T)tmp;
        }
        ...
        var listView = FindAncestor<ListView>(columnHeader);
