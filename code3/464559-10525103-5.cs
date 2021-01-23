    private void DeleteNode(IList<Node> flatNodes, Guid id)
    {
        var nodeToDelete = flatNodes.FirstOrDefault(n => n.Id == id);
        if (nodeToDelete != null)
        {
            var parent = flatNodes.First(n => n.Id == nodeToDelete.ParentId);
            parent.Children.Remove(nodeToDelete);
        }
     }
