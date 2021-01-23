	public Root FromJson(JsonReader reader)
	{
		while (reader.Read())
		{
			// Break on EndObject
			if (reader.TokenType == JsonToken.EndObject)
				break;
			// Only look for properties
			if (reader.TokenType != JsonToken.PropertyName)
				continue;
			switch ((string) reader.Value)
			{
				case "Number":
					reader.Read();
					Number = Convert.ToInt32(reader.Value);
					break;
				case "Partials":
					reader.Read(); // Read token where array should begin
					if (reader.TokenType == JsonToken.Null)
						break;
					var partials = new List<Partial>();
					while (reader.Read() && reader.TokenType == JsonToken.StartObject)
						partials.Add(new Partial().FromJson(reader));
					Partials = partials.ToArray();
					break;
				case "Numbers":
					reader.Read(); // Read token where array should begin
					if (reader.TokenType == JsonToken.Null)
						break;
					var numbers = new List<ulong>();
					while (reader.Read() && reader.TokenType != JsonToken.EndArray)
						numbers.Add(Convert.ToUInt64(reader.Value));
					Numbers = numbers;
					break;
			}
		}
		return this;
	}
