    private void button1_Click(object sender, EventArgs e)
 	{
		GridItem gi = propertyGrid1.SelectedGridItem;
		while (gi.Parent != null)
		{
			gi = gi.Parent;
		}
		foreach (GridItem item in gi.GridItems)
		{
			ParseGridItems(item); //recursive
		}
	}
	private void ParseGridItems(GridItem gi)
	{
		if (gi.GridItemType == GridItemType.Category)
		{
			foreach (GridItem item in gi.GridItems)
			{
				ParseGridItems(item);
			}
		}
		textBox1.Text += "Lable : "+gi.Label + "\r\n";
		if(gi.Value != null)
			textBox1.Text += "Value : " + gi.Value.ToString() + "\r\n";
	}
