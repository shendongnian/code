	public class TagViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public static Expression<Func<SiteTag, TagViewModel>> Select = t => new TagViewModel
		{
			Id = t.Id,
			Name = t.Name,
		};
