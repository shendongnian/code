	private int clicks = 0;
	
	
	 protected void myButton_Click(object sender, EventArgs e)
     {
		if(clicks == 1)
		{
			// do something
		}
		if(clicks == 2)
		{
			// do other things
		}
		if(clicks > 2)
		{
			// something else
		}
	
		clicks++;
	 }
