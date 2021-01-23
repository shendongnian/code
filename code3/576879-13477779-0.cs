    protected void RadGrid1_RowDrop(object sender, GridDragDropEventArgs e)
    {
       var ids = (from GridDataItem item in this.RadGrid1.Items
                select Convert.ToInt32(item.GetDataKeyValue("ID"))).ToList();
    
       // Rearranges item in requested order
       if (ids.Count > 0 && e.DestDataItem != null)
       {
         // Get the index of destination row
         int destItem = ids.FirstOrDefault(item => 
           item == Convert.ToInt32(e.DestDataItem.GetDataKeyValue("ID")));
    
         int destinationIndex = destItem == 0 ? -1 : ids.IndexOf(destItem);
    
         foreach (GridDataItem draggedItem in e.DraggedItems)
         {
           int draggedId = ids.FirstOrDefault(item => 
             item == Convert.ToInt32(draggedItem.GetDataKeyValue("ID")));
    
           if (draggedId != 0 && destinationIndex > -1)
           {
             // Remove and re-insert at specified index
             ids.Remove(draggedId);
             ids.Insert(destinationIndex, draggedId);
           }
         }
       }
    
       // Update each entity's display orders based on the given order
       MyUpdateDisplayOrder(ids);
    
       RadGrid1.Rebind();
    }
