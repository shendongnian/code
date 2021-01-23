    private void PopulateTreeView()
    {
        treeDepartments.Nodes.Clear();
        String strConn = "Server =server;Database =DB;Integrated Security = True;";
        SqlConnection conn = new SqlConnection(strConn);
        SqlDataAdapter da = new SqlDataAdapter("Select * from tSubDepartments", conn);
        SqlDataAdapter daCategories = new SqlDataAdapter("Select * from tDepartments", conn);
        da.Fill(ds, "tSubDepartments");
        daCategories.Fill(ds, "tDepartments");
        ds.Relations.Add("Dept_SubDept", ds.Tables["tDepartments"].Columns["dpCode"], ds.Tables["tSubDepartments"].Columns["dpCode"]);
        foreach (DataRow dr in ds.Tables["tDepartments"].Rows)
        {
            TreeNode tn = new TreeNode(dr["dpName"].ToString());
            tn.Tag = dr["dpID"]; //put the ID into the Tag property of the node
            foreach (DataRow drChild in dr.GetChildRows("Dept_SubDept"))
            {
                 TreeNode childTn = new TreeNode(drChild["sdName"].ToString());
                 childTn.Tag = drChild["sdID"];
                 tn.Nodes.Add(childTn);
            }
            treeDepartments.Nodes.Add(tn);
        }
    }
