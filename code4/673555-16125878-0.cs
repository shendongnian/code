    protected void Page_Load(object sender, EventArgs e)
    {
		int startInt = 100;
		ListBox lb1 = new ListBox();
		form1.Controls.Add(countDown(startInt, lb1));
    }
	public static ListBox countDown(int integer, ListBox lb)
	{
		ListItem li = new ListItem();
		
		if (integer == 1)
		{
			li.Text= integer.ToString();
			lb.Items.Add(li);
		}
		else
		{
			li.Text = integer.ToString();
			lb.Items.Add(li);
			integer--;
			countDown(integer, lb);
		}
		return lb;
		
	}   
