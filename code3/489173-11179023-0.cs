    public class Processor
	{
		public List<SortableItem> SortableItems { get; set; }
		
		public Processor()
		{
			SortableItems = new List<SortableItem>();
			SortableItems.Add(new SortableItem { PropA = "b" });
			SortableItems.Add(new SortableItem { PropA = "a" });
			SortableItems.Add(new SortableItem { PropA = "c" });
		}
		
		public void SortItems(Func<SortableItem, IComparable> keySelector, bool isAscending)
		{
			if(isAscending)
				SortableItems = SortableItems.OrderBy(keySelector).ToList();
			else
				SortableItems = SortableItems.OrderByDescending(keySelector).ToList();
		}
	}
