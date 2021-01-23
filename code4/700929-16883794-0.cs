	public class Item
	{
		public Item(Thumbnail thumbnail)
		{
			this.thumbnail = thumbnail;
		}
		
		public string description { get; set; }
		public string item_uri { get; set; }
		public thumbnail thumbnail { get; }
	}
