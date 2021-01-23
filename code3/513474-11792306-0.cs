     protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
     {
         int currentRowIndex = Int32.Parse(e.CommandArgument.ToString());
         LinkButton bf = (LinkButton)gv.Rows[currentRowIndex].Cells[1].Controls[0];
         ...
     }
  
