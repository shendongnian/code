    {
        GridView1.EditIndex = e.NewEditIndex;
        bindGvEdit();
    }
    protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        bindGvEdit();
    }
