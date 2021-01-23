    public class MapFrom
	{
		private readonly IDictionary<string, string> columnMapDictionary =
			new Dictionary<string, string>();
		
		public MapFrom(string[] columns)
		{
			foreach (var column in columns)
			{
				columnMapDictionary.Add(column, null);
			}
		}
		
		public void To<T>(params Expression<Func<T, object>>[] properties)
		{
			var index = 0;
			foreach (var columnMap in columnMapDictionary.ToDictionary(k => k.Key))
			{
				var member = (properties[index++].Body as MemberExpression);
				var propertyName = member.Member.Name;
				columnMapDictionary[columnMap.Key] = propertyName;	
			}
		}
	}
