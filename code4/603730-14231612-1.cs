    protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e) 
    {
      if (e.Row.RowType = DataControlRowType.DataRow)
      {
        //Check your condition here
        //Get Id from here and based on Id check value in the 
        //underlying dataSource Row Where you have "Done" column Value
        // e.g.
        // (gridview.DataSource as DataTable), now you can find your row and cell 
        // of "Done"
        If(Condition True)
        {
            e.Row.BackColor = Drawing.Color.Red  // your color settings 
        }
       }
    }
