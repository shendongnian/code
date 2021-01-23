	private List<object> GetVisibleItemsFromListbox(ListBox listBox, FrameworkElement parentToTestVisibility)
	{
		var items = new List<object>();
		foreach (var item in PhotosListBox.Items)
		{
			if (IsUserVisible((ListBoxItem)listBox.ItemContainerGenerator.ContainerFromItem(item), parentToTestVisibility))
			{
				items.Add(item);
			}
			else if (items.Any())
			{
				break;
			}
		}
		return items;
	}
