    private void DeleteNode(List<Node> nodes, Guid id)
    {
        var nodeToDelete = nodes.FirstOrDefault(n => n.Id == id);
        if (nodeToDelete != null)
        {
            var parent = nodes.First(n => n.Id == nodeToDelete.ParentId);
            parent.Children.Remove(nodeToDelete);
        }
     }
