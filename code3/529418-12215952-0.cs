    void Control_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
          if(e.Row.Cells[3].Text == "1")
          {
             e.Row.Cells[4].Text = ""; // erase the value of cell
             //You can use also to cell : Attributes["style"] = "display:none";
          
          }
          else
          {
            .... 
          }
      }
  }
