    Node<MenuElement> rootNode = <Any node of the collection>.Root;
    var mandatoryNodes = rootNode.SelfAndDescendants.Where(n => n.Value.IsMandatory);
    foreach (var mandatoryNode in mandatoryNodes)
    {
        foreach (var node in mandatoryNode.SelfAndAncestors.Reverse()); // Reverse because you want from root to node)
        {
            var spaces = string.Empty.PadLeft(node.Level); // Each node knows it's level
            Console.WriteLine("{0}{1}. {2}", spaces, node.Value.Position, node.Value.Label);
        } 
    }
