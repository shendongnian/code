    public List<Node> getNotifications(int id)
    {
        var bucket = new List<Node>(notificationTreeNodes.Count);
        
        foreach (var notificationTreeNode in notificationTreeNodes)
        {
            Node nd = new Node();
            ...
            bucket.Add(nd);
        }
        return bucket;
    }
