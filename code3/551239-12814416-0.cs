    protected void MyRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e) 
    {
       // Use FindControl, but start from the context of the RepeaterItem.
       //
       HtmlTableCell cell = e.item.FindControl("CellID") as HtmlTableCell;
    
       if ( cell != null )
       {
          // Do what you gotta do.
       }
    }
