    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow) //skip header row
        {
    DataTable dt= GetStatusTable();
            DropDownList ddStatus= (DropDownList)e.Row.Cells[5].FindControl("DropDownList");
            ddStatus.DataTextField="Status";
            ddStatus.DataValueField="ID" ;
    ddStatus.DataSource=dt;//this datatable should be filled with all the possible values for the status
    ddStatus.DataBind();
        }
    }
