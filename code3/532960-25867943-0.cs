    	public class CustomConverter : JsonConverter
		{
			/// <summary>
			/// Use a privately create serializer so we don't re-enter into CanConvert and cause a Newtonsoft exception
			/// </summary>
			private readonly JsonSerializer noRegisteredConvertersSerializer = new JsonSerializer();
			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				bool meetsCondition = false; /* add condition here */
				if (!meetsCondition)
					writer.WriteNull();
				else
					noRegisteredConvertersSerializer.Serialize(writer, value);
			}
			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				throw new NotImplementedException();
			}
			public override bool CanConvert(Type objectType)
			{
                // example: register accepted conversion types here
				return typeof(IDictionary<string, object>).IsAssignableFrom(objectType);
			}
		}
