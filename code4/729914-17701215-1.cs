    foreach (var item in agencyListRoot)
    {            
        if (item.HeirID.ToString() == "/1/")
        {
            group = new TreeNode(item.AgencyName.ToString());
            root.ChildNodes.Add(group);
        } 
        else if (item.HeirID.ToString() == "/1/2/")
        {
            TreeNode childNodeU = new TreeNode(item.AgencyName.ToString());
            group.ChildNodes.Add(childNodeU);
        }
    }
