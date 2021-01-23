    private void DeleteNode(IList<Node> flatNodes, Guid id)
    {
        var nodeToDelete = flatNodes.FirstOrDefault(n => n.Id == id);
        if (nodeToDelete != null)
        {
            var parent = flatNodes.First(n => n.Id == nodeToDelete.ParentId);
            parent.Children.Remove(nodeToDelete);
        }
    }
    private void DeleteNodeFromFlatDictionary(IDictionary<Guid, Node> flatNodes, Guid id)
    {
        if (!flatNodes.ContainsKey(id)) return;
        var nodeToDelete = flatNodes[id];
        parent[nodeToDelete.ParentId].Children.Remove(id);
    }
