		private List<ToolStripMenuItem> getContextMenuItems(ToolStripItemCollection items)
		{
			List<ToolStripMenuItem> result = new List<ToolStripMenuItem>();
			foreach (ToolStripMenuItem item in items)
			{
				result.Add(item);
				if (item.HasDropDownItems)
				{
					result.AddRange(this.getContextMenuItems(item.DropDownItems));
				}
			}
			return result;
		}
