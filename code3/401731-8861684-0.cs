    const string nodeKey = "hostNode";
    TreeNode tn1 = new TreeNode("My Node");
    tn1.Name = nodeKey; // This is the name (=key) for the node.
    TreeNode tn2 = new TreeNode("My Node2");
    tn2.Name = "otherKey"; // This is the key for node 2.
                                    
    treeView1.Nodes.Add(tn1); // Add node1.
    treeView1.Nodes.Add(tn2); // Add node2.
