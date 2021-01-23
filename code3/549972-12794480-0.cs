        public static FrameworkElement FindVisualChild(this FrameworkElement root, string name)
        {
            FrameworkElement temp = root.FindName(name) as FrameworkElement;
            if (temp != null)
                return temp;
            foreach (FrameworkElement element in root.GetVisualDescendents())
            {
                temp = element.FindName(name) as FrameworkElement;
                if (temp != null)
                    return temp;
            }
            return null;
        }
        public static IEnumerable<FrameworkElement> GetVisualDescendents(this FrameworkElement root)
        {
            Queue<IEnumerable<FrameworkElement>> toDo = new Queue<IEnumerable<FrameworkElement>>();
            toDo.Enqueue(root.GetVisualChildren());
            while (toDo.Count > 0)
            {
                IEnumerable<FrameworkElement> children = toDo.Dequeue();
                foreach (FrameworkElement child in children)
                {
                    yield return child;
                    toDo.Enqueue(child.GetVisualChildren());
                }
            }
        }
        public static IEnumerable<FrameworkElement> GetVisualChildren(this FrameworkElement root)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(root); i++)
            {
                yield return VisualTreeHelper.GetChild(root, i) as FrameworkElement;
            }
        }
