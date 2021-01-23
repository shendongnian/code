    protected void gvEmployeeList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "name")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = gvEmployeeList.Rows[index];
            string deptID = gridview1.DataKeys[index].Value.ToString().Trim();
             DataTable dtEmplist = new DataTable();
            dtEmplist = managerbiz.getFilterEmployeeList(deptID);
            if (dtEmplist.Rows.Count > 0)
            {
                gridview1.DataSource = dtEmplist;
                gridview1.DataBind();
            }
            else
            {
                lblMsg.Text = "No Data Available";
            }
        }
    }
