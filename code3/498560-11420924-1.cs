    protected void RowDataBound(Object sender, GridViewRowEventArgs e)
       {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
           // Retrieve the underlying data item. In this example
           // the underlying data item is a DataRowView object. 
           DataRowView rowView = (DataRowView)e.Row.DataItem;
           // Retrieve the state value for the current row. 
           String state = rowView["state"].ToString();
    
            //format color of the as below 
            if(state == "Closed")
                    (e.Row.FindControl("lbl1") as Label).BackColor  = Color.Red;
    
            if(state == "Open")
                    (e.Row.FindControl("lbl1") as Label).BackColor = Color.Green;
            if(state == "Waiting")
                    (e.Row.FindControl("lbl1") as Label).BackColor = Color.Yellow;
 
       }
    }
