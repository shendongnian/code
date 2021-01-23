    CheckBox chx;
    chx.Tag = "Chart 1"; // put these tags in an enum or at least constants
    chx.Click += chx_Click; 
    
    void chx_Click(object sender, RoutedEventArgs e)
    {
    	CheckBox chx = sender as CheckBox;
    	if (chx != null && chx.Tag != null)
    	{
    		switch (chx.Tag)
    		{
    			case "Chart 1": 
                            myChart1.Visibility = chx.IsChecked? Visibility.Visible: Visibility.Collapsed;  
    			    break;
    			case "Chart 2": //...
    				break;
    			default:
    				break;
    		}
    	}
    }
