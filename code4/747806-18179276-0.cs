	class Item
	{
		.....
		public virtual ICollection<SubItem> SubItems { get; set; }
		public virtual ICollection<Category> Categories { get; set; }
	}
