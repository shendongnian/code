    void Main()
    {
        //Create a treeview with a root node.
        TreeView tv = new TreeView();
        tv.ShowNodeToolTips = true; //Turn on tooltips for this demo.
        tv.Nodes.Add(new TreeNode("Root"));
    
        //These may need ordering by path before you start.
        var tfsTestCases = new[]
        {
            new WorkItem { Path = "Module/Feature1/SubFeature1/Test1", WorkItemId = 1, },
            new WorkItem { Path = "Module/Feature1/SubFeature1/Test2", WorkItemId = 2, },
            new WorkItem { Path = "Module/Feature1/SubFeature2/Test1", WorkItemId = 3, },
            new WorkItem { Path = "Module/Feature1/SubFeature2/Test2", WorkItemId = 4, },
            new WorkItem { Path = "Module/Feature2/SubFeature1/Test1", WorkItemId = 5, },
            new WorkItem { Path = "Module/Feature2/SubFeature1/Test2", WorkItemId = 6, },
        };
    
        //Looping through the test cases...
        foreach (var testCase in tfsTestCases)
        {
            //Start at the root of the tree for each work item.
            TreeNode lastNode = tv.Nodes[0];
    
            //Loop through each part of the path and create a new node.
            //Use the NodeCollection from the one we just created each time through the loop.
            foreach (var part in testCase.Path.Split('/'))
                lastNode = AddTreeNode(lastNode.Nodes, part);
    
            //Set the Tag on the last node in the loop, this is the one with the actual Test Case.
            //You can reference the Tag property of any "SelectedNode" to get access to the Work Item. If the Tag is null, then it's not a Test Case.
            lastNode.Tag = testCase;
            lastNode.ToolTipText = testCase.WorkItemId.ToString();	//Set for this DEMO.
        }
        //Display the tree.
        tv.Dump();
    }
    
    TreeNode AddTreeNode(TreeNodeCollection nodes, String path)
    {
        //Try and find a node in the collection matching the specified pathPath.
        var node = nodes.Cast<TreeNode>().Where(node => node.Text == path).SingleOrDefault();
        //If it's not found, create it and add it to the collection of nodes we just searched.
        if (node == null)
        {
            node = new TreeNode(path);
            nodes.Add(parentNode);
        }
        //We need this later, so pass it back.
        return node;
    }
    
    class WorkItem
    {
        public String Path { get; set; }
        public Int32 WorkItemId { get; set; }
        //etc.
    }
