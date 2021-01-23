    public static class ToolStripItemCollectionExt
	{
		/// <summary>
		/// Recusively retrieves all menu items from the input collection
		/// </summary>
		public static IEnumerable<ToolStripMenuItem> GetAllMenuItems(this ToolStripItemCollection items)
		{
			var allItems = new List<ToolStripMenuItem>();
			foreach (var item in items.OfType<ToolStripMenuItem>())
			{
				allItems.Add(item);
				allItems.AddRange(GetAllMenuItems(item.DropDownItems));
			}
			return allItems;
		}
	}
