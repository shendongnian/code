    foreach(InterfaceA item in tempList.getList())
    {
        rootNode = new TreeNode(item.GetName());
        rootNode.Tag = item
    
        InterfaceB itemB = item as InterfaceB;
        if(itemB != null)
        {
            childNode = new TreeNode(itemB.GetStatus())
            childNode.Tag = itemB
        }
    }
