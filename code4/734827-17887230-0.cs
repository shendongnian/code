	// Warning: untested code
	public class DictionaryConverter: JsonConverter
	{
		public override bool CanRead { get { return true; } }
		public override bool CanWrite { get { return false; } }
		public override bool CanConvert( Type objectType )
		{
			return objectType == typeof( Dictionary<string, string> );
		}
		public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
		{
			// Load JObject from stream
			JObject jObject = JObject.Load( reader );
			Dictionary<string, string> res = new Dictionary<string, string>( jObject.Count );
			foreach( var kvp in jObject )
				res[ kvp.Key ] = (string)kvp.Value;
			return res;
		}
		public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
		{
			throw new NotSupportedException();
		}
	}
