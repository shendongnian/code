    Node<MenuElement> rootNode = <Any node of the collection>.Root;
    var mandatoryNodes = rootNode.SelfAndDescendants.Where(n => n.Value.IsMandatory);
    foreach (var mandatoryNode in mandatoryNodes)
    {
        // It seems you need the ancestors and not only the parents of the mandatory nodes
        var mandatoryNodesWithReverseAncestors = mandatoryNode.SelfAndAncestors.Reverse(); // Reverse because you want from root to node
        foreach (var node in mandatoryNodesWithReverseAncestors)
        {
            var spaces = string.Empty.PadLeft(node.Level); // Each node knows it's level
            Console.WriteLine("{0}{1}. {2}", spaces, node.Value.Position, node.Value.Label);
        } 
    }
