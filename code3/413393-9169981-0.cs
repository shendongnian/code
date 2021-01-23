    int number = 1; 
    int maxnumber = 10000; 
    void LoadFavorites()
    {
    	for(var i = number; i <= maxnumber; i++)
    	{
    		if (Properties.Settings.Default.FavoriteList.Contains("'"+number+"'"))
    		{
    			this.listBox1.Items.Add(number);
    		}
    	}
    }
