    SqlDataReader dr = cmd.ExecuteReader();
    LinkButton3.Text = string.Empty;
    int i = 1;
    DataTable dt = new DataTable();
    dt.Load(dr);
    if (dt.Rows.Count > 1)
    {
        LinkButton3.Text = "Reporting Managers";  
        foreach(DataRow r in dt.Rows)
        {
            TreeNode parentNode = new TreeNode("L" + i++ + "Manager : " + r["Emp_Name"].ToString());
            parentNode.Value = r["Emp_ID"].ToString();
            TreeView1.Nodes.Add(parentNode);
            parentNode.ChildNodes.Add(new TreeNode("Short ID : " + r["Short_ID"].ToString()));
            parentNode.ChildNodes.Add(new TreeNode("EmpID : " + r["Emp_ID"].ToString()));
        }
    }
