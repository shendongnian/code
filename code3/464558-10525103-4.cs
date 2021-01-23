    private void DeleteNode(IList<Node> nodes, int id)
    {
        for (var index = 0; index < nodes.Count; index++)
        {
            var currentNode = nodes[index];
            if (currentNode.Id == id)
            {
                nodes.Remove(currentNode);
            }
            DeleteNode(currentNode.Children, id);
        }
    }
