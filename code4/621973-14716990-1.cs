    protected void repMenuParent_OnItemDataBound(object Sender, RepeaterItemEventArgs e)
    {        
    
       if ((e.Item.ItemType == ListItemType.Item) ||  (e.Item.ItemType == ListItemType.AlternatingItem))
       {
          //retrieve the id of the data item
          //I am not sure of your data item structure, but it will be something to this effect
          int nombre = Int32.Parse(e.Item.DataItem("NOMBRE"));
    
          if(this.ClickedIds.Contains(nombre))
          {
             ((Button)e.Item.FindControl("btnRepeaterParent")).ForeColor = System.Drawing.Color.FromArgb(69, 187, 32);
          }
       }            
    }
