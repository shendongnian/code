    public Node(T item)
    {
        _item = item;
        ParentNodeId = item.ParentNodeId;
        Children = new List<T>();
    }
