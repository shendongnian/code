	public class MyCustomConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType) {
			return true;
		}
		public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer) {
			throw new NotImplementedException();
		}
		public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer) {
			if (value == null) {
				writer.WriteNull();
				return;
			}
			string str = value.ToString().Substring(1, 2);
			writer.WriteValue(str);
		}
	}
	public class MaskContractResolver : DefaultContractResolver
	{
		protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization) {
			JsonProperty property = base.CreateProperty(member, memberSerialization);
			if (member.CustomAttributes.Any(x => typeof(MyAttr).IsAssignableFrom(x.AttributeType)))
				property.Converter = new MyCustomConverter();
			return property;
		}
	}
