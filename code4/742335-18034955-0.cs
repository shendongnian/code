	private string GetAllItems()
	{
		cFreeCustomization cfreeCust = new cFreeCustomization();
		var ls = cfreeCust.SelectedItems.FindAll(I => I.TypeName == this.TypeName);
		return string.Join(",", ls.Select(I => I.CategoryName).ToArray());	
	}
