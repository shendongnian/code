    List<AccessFieldSet> accessList = new List<AccessFieldSet>(); 
    private void GetRolesAccessData(Int32 RolesId) 
    {             
        C_RolesUsers Db = new C_RolesUsers(); 
        accessList = Db.GetRolesAccessData(RolesId);
        TreeRoles.Nodes.ActOnAllRecursively((node) =>
        {
            node.Checked = accessList.Any(afs => afs.AccessId == (int)node.Tag);
        });
    }
