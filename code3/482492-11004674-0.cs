	public class BarArrayConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			// Not properly implemented!
			return true;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			List<Bar> bars = new List<Bar>();
			// Read the first token after the start array
			reader.Read();
			// Parse elements of the array
			while (reader.TokenType == JsonToken.StartArray)
			{
				Bar b = new Bar();
				// Convert these as necessary to your internal structure. Note that they are nullable types.
				b.First = reader.ReadAsDecimal();
				b.Second = reader.ReadAsDecimal();
				// Read end array for this element
				reader.Read();
				// Pull off next array in list, or end of list
				reader.Read();
				bars.Add(b);
			}
			return bars;
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
	class Bar
	{
		public decimal? First;
		public decimal? Second;
	}
	class Foo
	{
		[JsonProperty("title")]
		public string Title { get; set; }
		[JsonConverter(typeof(BarArrayConverter))]
		[JsonProperty("raw_data")]
		public List<Bar> RawData { get; set; }
	}
