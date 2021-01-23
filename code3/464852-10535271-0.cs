    TreeView tree = new TreeView();
    foreach(string groupName in Groups) 
    { 
        var groupNode = new TreeNode(groupName); 
        foreach(KeyValuePair user in UserList) 
        {
            if(user.Key == groupNode)
            {
                var userNode = new TreeNode(user);
                groupNode.Add(userNode);
            }
        }
        tree.Add(groupNode);
    }
