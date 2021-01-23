    Node<MenuElement> rootNode = <Any node of the collection>.Root;
    var mandatoryNodes = rootNode.SelfAndDescendants.Where(n => n.Value.IsMandatory);
    // It seems you need the ancestors and not only the parents of the mandatory nodes
    var mandatoryNodesWithAncestors = mandatoryNodes.Select(n => n.SelfAndAncestors.Reverse()); // Reverse because you want from root to node
    
    foreach (var mandatoryNodesWithAncestor in mandatoryNodesWithAncestors)
    {
        foreach (var node in mandatoryNodesWithAncestor)
        {
            var spaces = string.Empty.PadLeft(node.Level); // Each node knows it's level
            Console.WriteLine("{0}{1}. {2}", spaces, node.Value.Position, node.Value.Label);
        } 
    }
