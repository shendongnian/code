    List<AccessFieldSet> accessList = new List<AccessFieldSet>(); 
    private void GetRolesAccessData(Int32 RolesId) 
    {             
        C_RolesUsers Db = new C_RolesUsers(); 
        accessList = Db.GetRolesAccessData(RolesId);
        foreach (TreeNode node in TreeRoles.Nodes)
        {
            CheckNodeRecursive(node, accessList);
        } 
    } 
 
    private void CheckNodeRecursive(TreeNode node, List<AccessFieldSet> accessList) 
    {
        for (int j = 0; j < accessList.Count; j++) 
        { 
            foreach (AccessFieldSet afs in accessList) 
            { 
                if ((int)node.Tag == afs.AccessId) 
                { 
                    node.Checked = true; 
                } 
            } 
        }
        foreach (TreeNode childNode in node.Nodes)
        {
            CheckNodeRecursive(childNode, accessList);
        }
    } 
