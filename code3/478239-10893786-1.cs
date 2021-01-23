    .invisible
    { 
       display:none;
    }
    protected void GridView1_DataBound(object sender, GridViewRowEventArgs e)
     {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text=="Locked")
            {
                  e.Row.Cells[0].CssClass = "invisible"
            }
         }
       }
