    public static FrameworkElement FindByName(string name, FrameworkElement root)
    {
        Stack<FrameworkElement> tree = new Stack<FrameworkElement>();
        tree.Push(root);
        while (tree.Count > 0)
        {
            FrameworkElement current = tree.Pop();
            if (current.Name == name)
                return current;
            int count = VisualTreeHelper.GetChildrenCount(current);
            for (int i = 0; i < count; ++i)
            {
                DependencyObject child = VisualTreeHelper.GetChild(current, i);
                if (child is FrameworkElement)
                    tree.Push((FrameworkElement)child);
            }
        }
        return null;
    }
