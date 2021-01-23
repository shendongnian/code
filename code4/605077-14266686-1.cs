    protected void dataGridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var ddl = (e.Row.FindControl("subjects") as DropDownList);
            ddl.DataSource = (e.Row.DataItem as Student).Subjects;
            ddl.DataBind();
         }
    }
