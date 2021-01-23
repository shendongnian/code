    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
          {
             if (e.Item is GridDataItem)
             {
               GridDataItem item = (GridDataItem)e.Item;
               Label txtProcessStatus = e.Item.FindControl("ProcessStatusLabel") as Label;
               if (txtProcessStatus.Text != "98") //your condition
               {
                 ImageButton img = (ImageButton)item["EditCommandColumn"].Controls[0]; //Accessing EditCommandColumn
                 img.Visible = false;
               }                  
           }
