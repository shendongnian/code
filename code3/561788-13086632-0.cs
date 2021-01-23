    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataTable dt = new DataTable();
            dt = Common.rundate();
            DropDownList ddl = e.Row.FindControl("DropDownList1") as DropDownList;
    
            ddl.DataTextField = "RunDate";
            ddl.DataValueField = "TempID";
            ddl.DataSource = dt;
            ddl.DataBind();
            HiddenField hdn=(HiddenField)row.Cells[cellindex].FindControl("hiddenField1");
            ddl.SelectedValue=hdn.Value;
        }
    
    }
