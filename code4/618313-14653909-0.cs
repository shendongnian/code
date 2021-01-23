	// Generic DragEnter
	private void ddEnter_DragEnter(object sender, DragEventArgs e)
	{
	    e.Effect = DragDropEffects.Move;
	}
	
	// ItemDrag Events
	private void fields_ItemDrag(object sender, ItemDragEventArgs e)
	{
	    fromBuilder = false;
	    fields.DoDragDrop(e.Item, DragDropEffects.Move);
	}
	
	private void builder_ItemDrag(object sender, ItemDragEventArgs e)
	{
	    fromBuilder = true;
	    packetBuilder.DoDragDrop(e.Item, DragDropEffects.Move);
	}
	
	// DragDrop Events
	private void builderAndFields_DragDrop(object sender, DragEventArgs e)
	{
	    ListViewItem i = new ListViewItem();
	    i = e.Data.GetData(typeof(ListViewItem)) as ListViewItem;
	
	    // Since this function works for both the builder and the fields,
	    // we have to check to see where we are dropping, the sender
	    // is the ListView we are dropping onto
	    Console.WriteLine(sender.Equals(packetBuilder));
	    if (sender.Equals(packetBuilder))
	    {
	        ListViewItem c = new ListViewItem();
	        c = (ListViewItem)i.Clone();
	        Point cp = packetBuilder.PointToClient(new Point(e.X, e.Y));
	        // Now, we have to check to see if we are reordering or adding
	        // So, we check the flag to see if the dragDrop was initiated 
	        // on the builder or on the fields ListView
	        Console.WriteLine(fromBuilder);
	        if (fromBuilder)
	        {
	            if (packetBuilder.HitTest(cp).Location.ToString() == "None")
	            {
	                packetBuilder.Items.Add(c);
	                packetBuilder.Items.Remove(i);
	            }
	            else
	            {
	                ListViewItem dragToItem = packetBuilder.GetItemAt(cp.X, cp.Y);
	                int dropIndex = dragToItem.Index;
	                packetBuilder.Items.Insert(dropIndex, c);
	                packetBuilder.Items.Remove(i);
	            }
	
	        }
	        else
	        {
	            if (packetBuilder.HitTest(cp).Location.ToString() == "None")
	                packetBuilder.Items.Add(c);
	            else
	            {
	
	                ListViewItem dragToItem = packetBuilder.GetItemAt(cp.X, cp.Y);
	                int dropIndex = dragToItem.Index;
	                packetBuilder.Items.Insert(dropIndex, c);
	            }
	        }
	    }
	    // If the sender is the fields listView, the user is trying to remove
	    // the item from the builder.
	    else
	    {
	        packetBuilder.Items.Remove(i);
	    }
	} 
