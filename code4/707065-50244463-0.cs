    public class IncludeIgnored : DefaultContractResolver
	{
		private readonly bool _includeIgnored;
		public IncludeIgnored(bool includeIgnored)
		{
			_includeIgnored = includeIgnored;
		}
		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
			foreach (var item in properties)
			{
				item.Ignored = !_includeIgnored;
			}
			return properties;
		}
	}
