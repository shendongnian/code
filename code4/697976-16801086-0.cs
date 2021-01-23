    string key, value, tempLine = "";
    
    using (StringReader reader = new StringReader(list))
    {
    	string line;
    	string[] split;
    	while ((line = reader.ReadLine()) != null)
    	{
    		// Do something with the line.
    		tempLine = line.Replace("[", "");
    		tempLine = tempLine.Replace("]", "");
    
    		split = tempLine.Split(':');
    		key = split[0];
    		value = split[1];
    		if (((TextBox)tabControl1.SelectedTab.Controls[0]).Text.Contains("[" + key + "]"))
    		{
    			((TextBox)tabControl1.SelectedTab.Controls[0]).Text = ((TextBox)tabControl1.SelectedTab.Controls[0]).Text.Replace("[" + key + "]", value);
    		}
    	}
    }
