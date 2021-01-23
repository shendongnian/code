    private void DeleteNode(IList<Node> nodes, Guid id)
    {
        Node nodeToDelete = null;
        foreach (var node in nodes)
        {
            if (node.Id == id)
            {
                nodeToDelete = node;
                break;
            }
            DeleteNode(node.Children, id);
        }
        if (nodeToDelete != null)
        {
            nodes.Remove(nodeToDelete);
        }
    }
