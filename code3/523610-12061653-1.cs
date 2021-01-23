    // changed to take TV as a parameter.
    private void countDown(TreeView tv, int num)
    {
        // Create and remember your root node.
        var root = new TreeNode("root");
        tv.Nodes.Add(root);
        // This to remember the last 'grouping node' created.  Start with
        // the root node to deal with starting values not divisible by 10.
        TreeNode group = root;
        for ( int i=num; i>0; i--)
        {
            // Is it divisble by 10, if so, start a new group 
            if (num % 10 == 0)
            {
                group = new TreeNode(i.ToString());
                root.Nodes.Add(group);
            }
            else
            {  
                // Not divisible, so add to last group (or root if no 
                // group yet started) 
                group.Nodes.Add(i.ToString());
            }
        }
    }
