     void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
      {
    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
         
          Label Label1= ((Label)e.Row.FindControl("Label1"));
          Label1.Text = "YOURDATA";
    
        }
    
      }
