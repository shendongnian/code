	public class Item : List<Item>
	{
		public string Name;
		
		private List<Item> LocateItems(string searchName)
		{
			if (this.Name == searchName)
				return (new [] { this }).ToList();
			
			var result =
				this
					.Select(s => s.LocateItems(searchName))
					.Where(x => x !=null && x.Count > 0)
					.FirstOrDefault();
			
			if (result != null)
				result.Add(this);
			
			return result;
		}
		
		public string LocateItem(string searchName)
		{
			var items = this.LocateItems(searchName);
			if (items == null)
				return null;
			else
				return String.Join(".", items.Select(i => i.Name).Reverse());
		}
	}
