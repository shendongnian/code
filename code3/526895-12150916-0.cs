    IEnumerable<IList<T>> CreateRollingWindow(IEnumerable<T> items, int size)
    {
        LinkedList<T> list = new LinkedList<T>();
        foreach(var item in items)
        {
            list.AddLast(item);
            if (list.Count == size)
            {
                yield return list.ToList();
                list.RemoveFirst();
            }
        }
    }
