    List<String> textBoxes = new List<String>();
    List<String> checkBoxes = new List<String>();
    foreach (TabPage mainPage in mainTabControl.TabPages)
    {
    	foreach (Control c in mainPage.Controls)
    	{
    		if (c is TabControl)
    		{
    			foreach (TabPage secondPage in ((TabControl)c).TabPages)
    			{
    				foreach (Control c2 in secondPage.Controls)
    				{
    					if (c is CheckBox)
    					    checkBoxes.Add(((CheckBox)c).Name + ":" + (((CheckBox)c).Checked ? "True" : "False"));
    					else if (c is TextBox)
    					    textBoxes.Add(((TextBox)c).Name + ":" + (((TextBox)c).Text));
    					//... add more for other controls to capture
    				}
    			}
    		}
    		else
    		{
    			if (c is CheckBox)
    			    checkBoxes.Add(((CheckBox)c).Name + ":" + (((CheckBox)c).Checked ? "True" : "False"));
    			else if (c is TextBox)
    			    textBoxes.Add(((TextBox)c).Name + ":" + (((TextBox)c).Text));
    			//... add more for other controls to capture
    		}
    	}
    }
