    // this is variable to retrieve Node list
    private static List<Node> listNode = new List<Node>();
    public static List<Node> GetDescendantOrSelfNodeList(Node node, string nodeTypeAlias)
    {
        if (node.NodeTypeAlias == nodeTypeAlias)
            listNode.Add(node);
        foreach (Node childNode in node.Children)
        {
            GetDescendantOrSelfNodeList(childNode, nodeTypeAlias);
        }
        return listNode;
    }
