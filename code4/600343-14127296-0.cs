    protected void grid_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
     if(e.Row.RowType == DataControlRowType.DataRow)
     {
       if((DateTime.Now - DateTime.Parse((e.Row.DataItem as DataRowView)["scheduledTime "])).TotalMinutes<=15)
           e.Row.BackColor = System.Drawing.Color.Red;
       else if  //... etc
     }
