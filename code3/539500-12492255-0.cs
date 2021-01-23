    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.Header)
        {
            for (int i = 0; i < e.Row.Cells.Count; i++)
            {
               DropDownList ddl = new DropDownList();
               ddl.DataSource = getImpacts();
               ddl.DataBind();
               e.Row.Cells[i].Controls.Add(ddl);
            }
        }
    }
