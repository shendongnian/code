    //Holders.
    string line = "";
    string[] items;
    ListViewItem listItem;
        
    //While there are lines to read.
    while((line = reader.ReadLine()) != null)
    {
    	items = line.Split('\t') //Split the line.
    	listItem = new ListViewItem(); //"Row" object.
    		
            //For each item in the line.
    		for (int i = 0; i < items.Length; i++)
    		{
    			listItem.SubItems.Add(items[i]); //Add it to the "Row" object.
    		}
    	
    	listView1.Items.Add(listItem); //Add the row object to the listview.
    }
