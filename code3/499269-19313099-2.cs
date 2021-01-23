    public void bindGvEdit()
    {
        GridView1.DataSource = obj1.SelectAlltbl();
        GridView1.DataBind();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        bindGvEdit();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindGvEdit();
    }
    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridView1.Rows[e.RowIndex];
        obj1.Id = Convert.ToInt32(GridView1.DataKeys[row.RowIndex].Value);
        obj1.Name = ((TextBox)row.Cells[1].Controls[1]).Text;
        obj1.Description = ((TextBox)row.Cells[2].Controls[1]).Text;
        obj1.Updatetbl();
        GridView1.EditIndex = -1;
        bindGvEdit();
    }
