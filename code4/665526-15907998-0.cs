    if (e.Row.RowType == DataControlRowType.DataRow)
    {
      Label lbl=(Label)e.Row.FindControl("lblStatus");
       if (lbl.Text == "1")
       {
          lbl.Text = "IN";
          e.Row.Cells[2].BackColor = Color.Blue;
          e.Row.Cells[2].ForeColor = Color.White;
       }
    }
