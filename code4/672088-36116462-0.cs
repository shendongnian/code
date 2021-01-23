    /// <summary>
	/// Converts a <see cref="KeyValuePair{TKey,TValue}"/> to and from JSON.
	/// </summary>
	public class DictionaryAsKVPConverter<TKey, TValue> : JsonConverter
	{
		/// <summary>
		/// Determines whether this instance can convert the specified object type.
		/// </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>
		/// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
		/// </returns>
		public override bool CanConvert(Type objectType)
		{
			if (!objectType.IsValueType && objectType.IsGenericType)
				return (objectType.GetGenericTypeDefinition() == typeof(Dictionary<,>));
			return false;
		}
		/// <summary>
		/// Writes the JSON representation of the object.
		/// </summary>
		/// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
		/// <param name="value">The value.</param>
		/// <param name="serializer">The calling serializer.</param>
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			var dictionary = value as IDictionary<TKey, TValue>;
			serializer.Serialize(writer, dictionary);
		}
		/// <summary>
		/// Reads the JSON representation of the object.
		/// </summary>
		/// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
		/// <param name="objectType">Type of the object.</param>
		/// <param name="existingValue">The existing value of object being read.</param>
		/// <param name="serializer">The calling serializer.</param>
		/// <returns>The object value.</returns>
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			Dictionary<TKey, TValue> dictionary;
			if (reader.TokenType == JsonToken.StartArray)
			{
				dictionary = new Dictionary<TKey, TValue>();
				reader.Read();
				while (reader.TokenType == JsonToken.StartObject)
				{
					var kvp = serializer.Deserialize<KeyValuePair<TKey, TValue>>(reader);
					dictionary[kvp.Key] = kvp.Value;
					reader.Read();
				}
			}
			else if (reader.TokenType == JsonToken.StartObject)
				// Use DummyDictionary to fool JsonSerializer into not using this converter recursively
				dictionary = serializer.Deserialize<DummyDictionary>(reader);
			else
				dictionary = new Dictionary<TKey, TValue>();
			return dictionary;
		}
		/// <summary>
		/// Dummy to fool JsonSerializer into not using this converter recursively
		/// </summary>
		private class DummyDictionary : Dictionary<TKey, TValue> { }
	}
