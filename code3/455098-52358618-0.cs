    public static IEnumerable<T> FindVisualChildren<T>([NotNull] this DependencyObject parent) where T : DependencyObject
    {
        if (parent == null)
            throw new ArgumentNullException(nameof(parent));
        var queue = new Queue<DependencyObject>(new[] {parent});
        while (queue.Any())
        {
            var reference = queue.Dequeue();
            var count = VisualTreeHelper.GetChildrenCount(reference);
            for (var i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(reference, i);
                if (child is T children)
                    yield return children;
                queue.Enqueue(child);
            }
        }
    }
