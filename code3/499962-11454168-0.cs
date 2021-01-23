	public ListView folder_listView = new ListView();
   
	public void Build()
	{
		folder_listView.Items.AddRange(new ListViewItem[]
		{
            Item("First Col", 
				new ListViewItem.ListViewSubItem(){ Text = "Second Col" }
				),
            Item("Another col", 
				new ListViewItem.ListViewSubItem(){ Text = "Another Second Col" }, 
				new ListViewItem.ListViewSubItem(){ Text = "Another Third Col" }
				)
		});
	}
	private static ListViewItem Item(string text, params ListViewItem.ListViewSubItem[] subItems)
	{
		ListViewItem item = new ListViewItem(text);
		item.SubItems.AddRange(subItems);
		return item;
	}
