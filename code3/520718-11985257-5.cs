    protected void GridView1_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {           
            TextBox t = (TextBox)e.Row.FindControl("ControlID"); 
            t.Text = "Some Text";
        }
   }
