    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
       {
          GridView gv = (GridView)sender;
          // Change the row state
          gv.Rows[e.NewEditIndex].RowState = DataControlRowState.Edit;
       }
