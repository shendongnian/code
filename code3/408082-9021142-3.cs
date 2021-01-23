    public static void RemoveFirst<T>(LinkedList<T> list, Predicate<T> predicate)
    {
        var node = list.First;
        while (node != null)
        {
            if (predicate(node.Value))
            {
                list.Remove(node);
                return;
            }
            node = node.Next;
        }
    }
