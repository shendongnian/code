    List<AccessFieldSet> accessList = new List<AccessFieldSet>(); 
    private void GetRolesAccessData(Int32 RolesId) 
    {             
        C_RolesUsers Db = new C_RolesUsers(); 
        accessList = Db.GetRolesAccessData(RolesId);
        TreeRoles.Nodes.ActOnAllRecursively((node) =>
        {
            foreach (AccessFieldSet afs in accessList) 
            { 
                if ((int)node.Tag == afs.AccessId) 
                { 
                    node.Checked = true; 
                } 
            } 
        });
    }
