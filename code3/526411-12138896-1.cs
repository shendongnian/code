    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           DropDownList ddl = (DropDownList)e.Row.FindControl("DropDownList1");
           DropDownList dd2 = (DropDownList)e.Row.FindControl("DropDownList2");
              ....
        }
    
    }
