    //One loop through all records in database
    while (Reader.Read())
    {
    	//Another loop through all the control
    	foreach (ToolStripMenuItem item in items)
    	{
    		if (item.Name == Reader[0].ToString())
    		{
    			item.Visible = true;
    		}
    		else
    		{
    			menuActive(item.DropDown.Items);
    		}
    	}
    }
