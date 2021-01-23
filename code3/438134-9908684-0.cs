    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string id = ...
        string notes = ...    
        UpdateDB(id, notes);    
        GridView1.EditIndex = -1;
        bind_grid();
    }
