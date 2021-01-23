    var node = list.First;
    while (node != null)
    {
        var nextNode = node.Next;
        if (predicate(node.Value))
        {
            list.Remove(node);
        }
    }
