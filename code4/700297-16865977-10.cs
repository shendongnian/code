    IEnumerable items = items
		.Select(item =>
			{
				item.SubItems.Where(sub => sub.ID = 1);
				return item;
			}
		);
