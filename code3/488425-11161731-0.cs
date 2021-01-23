    public Node Find(string stringToFind)
    {
        // find the string, starting with the current instance
        return Find(this, stringToFind);
    }
    // Search for a string in the specified node and all of its children
    public Node Find(Node node, string stringToFind)
    {
        if (node.Content.Contains(stringToFind))
            return node;
 
        foreach (var child in node.Children) 
        { 
            var result = Find(child, stringToFind);
            if (result != null)
                return result;
        }
        
        return null;
    }
