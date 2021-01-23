    void GridView1GridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    { 
      if(e.Row.RowType == DataControlRowType.DataRow)
      {
        //find the literal
        var literal1 = e.Item.FindControl("literal1") as Literal;
        if (literal1 != null)
        {
          literal1.Text = "<p>hi some text here</p>";
        }
       }
      }
