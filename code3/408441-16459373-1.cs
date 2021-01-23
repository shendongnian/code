    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Student item = e.Row.DataItem as Student;
                if (item != null)
                {
                    var ddl = e.Row.FindControl("ddlAge") as DropDownList;
                    if (ddl == null) return;
                    ddl.SelectedValue = item.Age.ToString();
                }
    
            }
        }
