	class Program
	{
		static void Main(string[] args)
		{
			AutoMapper.Mapper.CreateMap<ParentSource, ParentDestination>().ConvertUsing<CustomTypeConverter>();
			ParentSource ps = new ParentSource() { parentId = Guid.NewGuid() };
			for (int i = 0; i < 3; i++)
			{
				ps.children.Add(new ChildSource() { childId = Guid.NewGuid() });
			}
			var mappedObject = AutoMapper.Mapper.Map<ParentDestination>(ps);
		}
	}
	public class ParentSource
	{
		public ParentSource()
		{
			children = new HashSet<ChildSource>();
		}
		public Guid parentId { get; set; }
		public ICollection<ChildSource> children { get; set; }
	}
	public class ChildSource
	{
		public Guid childId { get; set; }
	}
	public class ParentDestination
	{
		public ParentDestination()
		{
			children = new HashSet<ChildDestination>();
		}
		public Guid parentId { get; set; }
		public ICollection<ChildDestination> children { get; set; }
	}
	public class ChildDestination
	{
		public Guid childId { get; set; }
		public Guid parentId { get; set; }
		public ParentDestination parent { get; set; }
	}
	public class CustomTypeConverter : AutoMapper.TypeConverter<ParentSource, ParentDestination>
	{
		protected override ParentDestination ConvertCore(ParentSource source)
		{
			var result = new ParentDestination() { parentId = source.parentId };
			result.children = source.children.Select(c => new ChildDestination() { childId = c.childId, parentId = source.parentId, parent = result }).ToList();
			return result;
		}
	}
