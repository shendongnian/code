    public static IEnumerable<T> FindLogicalChildren<T>([NotNull] this DependencyObject parent) where T : DependencyObject
    {
        if (parent == null)
            throw new ArgumentNullException(nameof(parent));
        var queue = new Queue<DependencyObject>(new[] {parent});
        while (queue.Any())
        {
            var reference = queue.Dequeue();
            var children = LogicalTreeHelper.GetChildren(reference);
            var objects = children.OfType<DependencyObject>();
            foreach (var o in objects)
            {
                if (o is T child)
                    yield return child;
                queue.Enqueue(o);
            }
        }
    }
