    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
    	string pathdoubleClicked = listView1.FocusedItem.Tag.ToString();
    	
    	if (System.IO.Directory.Exists(pathdoubleClicked))
    	{
    		PopulateListView(pathdoubleClicked);
    	}
    	else
    	{
    		Process.Start(pathdoubleClicked);
    	}
    	
    	// ?
    	simpleStack.Push(pathdoubleClicked);
    }
