    foreach(_Amortizacion amNode in amortList)
    {
        // Using Null Coalescing to create the node if it doesn't exist.
        // First check if group is null. If it isn't, try to pull the node and create it if it doesn't exist.
        TreeNodeCollection workingNode = !string.IsNullOrEmpty(amNode.Grupo) ?
            (tvLoans.Nodes[amNode.Grupo] ?? tvLoans.Nodes.Add(amNode.Grupo)).Nodes :
            tvLoans.Nodes;
        // At this point, workingNode is the NodeCollection we'll be adding the person to. Creating if doesn't exist.
        workingNode = (workingNode[amNode.Personas] ?? workingNode.Add(amNode.Personas)).Nodes;
        // Now we're adding the actual loan record to the person Node.
        workingNode.Add(new TreeNode(/* This is what will show up in TreeView. */) { Tag = amNode, Name = /* Specify a key here, in case you want to search. */ });
    }
