    protected void RowDataBound(Object sender, GridViewRowEventArgs e)
       {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            //access label like this 
            //Label lb = e.Row.FindControl("label") as Label;
    
            //format color of the as below 
            if(e.Row.Cells[0].Text == "ABC")
                    (e.Row.FindControl("lbl1") as Label).BackColor  = Color.Red;
    
            if(e.Row.Cells[0].Text == "CBA")
                    (e.Row.FindControl("lbl1") as Label).BackColor = Color.Green;
        }
    }
