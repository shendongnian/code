    TreeNode newNode = new TreeNode(permission.ToString());
    newNode.SelectAction = TreeNodeSelectAction.None; // no Link
    
        if (shouldDisableCheckbox)
        {
            // Set a class so disabled nodes can be formatted thru CSS
            // and be identifiable as disabled in Javascript.
            newNode.Text = "<span class=disabledTreeviewNode>" + newNode.Text +"</span>";
        }
    
    nodes.Add (newNode);
