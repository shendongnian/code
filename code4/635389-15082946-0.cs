    string[] menuGroup = ((from DataRow row1 in _ds.Tables["Rest_grdvitems"].Rows
                         orderby row1["Menu_Group"]
                         select row1["Menu_Group"].ToString()).Distinct()).ToArray();
    TreeNode node = new TreeNode("All Items");
    TV_Categories_List.BeginUpdate();
    TV_Categories_List.Nodes.Add(node);
    foreach (string menuitem in menuGroup)
    {
        TreeNode node1 = new TreeNode(menuitem);
        TV_Categories_List.Nodes.Add(node1);
    }
    TV_Categories_List.EndUpdate();
