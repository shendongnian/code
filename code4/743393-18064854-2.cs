    protected void gridviewID_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        int totalyes=0;
        int totalno=0;
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Assuming the column containg yes or no is the third column.
           if( e.Row.Cells[2].Text.ToLower()=="yes")
           {
             totalyes++
           }
          else
          {
             totalno++;	
           }
        else if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[0].Text="Total no. of Yes: "+ totalyes.ToString();
            e.Row.Cells[1].Text="Total no. of No: "+totalno.ToString();
        }
    }
