    protected void DeleteClick(object sender,EventArgs e)
    {
        DataTable table = (DataTable)Session["reptable"];
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            CheckBox chkDelete = GridView1.Rows[i].FindControl("chkDelete") as CheckBox;
            if (chkDelete != null && chkDelete.Checked)
            {
                var empId = GridView1.DataKeys[i]["EmpID"];
                DataRow dr = table.Select(String.Format("EmpID={0}", empId)).First();
                if (dr != null)
                dr.Delete();
            }
        }
        //Rebind your grid view here to view the changes e.g
        GridView1.DataSource = table;
        GridView1.DataBind();
    }
 
