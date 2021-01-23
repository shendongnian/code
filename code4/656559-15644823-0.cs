      protected void GridView1_RowDataBound1(object sender, GridViewRowEventArgs e)
      {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label a = e.Row.FindControl("Label3") as Label;
            if (a.Text == "Sam")
            {
               
                e.Row.Cells[0].Enabled = true;
                e.Row.Cells[1].Enabled = false;
                e.Row.Cells[2].Enabled = false;
                e.Row.Cells[3].Enabled = false;
            }
        }
    }
