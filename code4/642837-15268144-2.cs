    public void lbRefresh()        
	{
		//create itemsList for listbox
		ArrayList itemsList = new ArrayList();
		//count how many information you wana to add
		//here I count how many columns I have in dataGrid1
		int count = dataGrid1.Columns.Count;
		//for cycle to add my strings of columns headers into an itemsList
		for (int i = 0; i < count; i++)
		{
			itemsList.Add(dataGrid1.Columns[i].Header.ToString());
		}
		//simply refresh my itemsList into my listBox1
		listBox1.ItemsSource = itemsList;
	}
