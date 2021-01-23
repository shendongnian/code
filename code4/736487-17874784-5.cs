    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        GridView gridView1= (GridView)sender;
       // Change the row state
        gridView1.Rows[e.NewEditIndex].RowState = DataControlRowState.Edit;
    }
