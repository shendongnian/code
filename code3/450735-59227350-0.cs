	//short helper class to ignore some properties from serialization
	public class IgnorePropertiesResolver : DefaultContractResolver
	{
		private IEnumerable<string> _propsToIgnore;
		public IgnorePropertiesResolver(IEnumerable<string> propNamesToIgnore)
		{
			_propsToIgnore = propNamesToIgnore;
		}
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
		{
			JsonProperty property = base.CreateProperty(member, memberSerialization);
			property.ShouldSerialize = (x) => { return !_propsToIgnore.Contains(property.PropertyName); };
			return property;
		}
	}
