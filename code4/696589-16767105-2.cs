    public object FindNode()
    {
        var queue = new Queue<TreeNode>();
    
        foreach (var n in treeView1.Nodes)
        {
             // Add all root nodes to queue
             queue.Enqueue(n);
        }
    
        while (queue.Count > 0)
        {
            // Take the next node from the front of the queue
            var node = queue.Dequeue();
    
            // Check if myString contains node text
            if (myString.Contains(node.Text))
                return node.Tag;
    
            // Add the node’s children to the back of the queue
            foreach (var child in node.Children)
            {
                queue.Enqueue(child);
            }
        }
    
        // None of the nodes matched the specified string.
        return null;
    }
