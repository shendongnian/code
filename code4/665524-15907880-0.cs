    // In template column,
    if (e.Row.RowType == DataControlRowType.DataRow)
    {
       var status = (Label)e.Row.FindControl("lblStatus");
       if (status.Text == "1")
       {
          e.Row.Cells[2].Text = "IN";
          e.Row.Cells[2].BackColor = Color.Blue;
          e.Row.Cells[2].ForeColor = Color.White;
       }
    }
