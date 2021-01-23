    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        object source;
        //[42, 23]
        if (reader.TokenType == JsonToken.StartArray)
        {
            reader.Read();
            var values = new List<object>();
            while (reader.TokenType != JsonToken.EndArray)
            {
                values.Add(reader.Value);
                reader.Read();
            }
            reader.Read();
            source = values.ToArray();
        }
        else if (reader.TokenType == JsonToken.StartObject)//{"subtrahend": 23, "minuend": 42}
        {
            reader.Read();
            var values = new Dictionary<string, object>();
            while (reader.TokenType != JsonToken.EndObject)
            {
                if (reader.TokenType != JsonToken.PropertyName)
                    throw new FormatException("Expected a property name, got: " + reader.TokenType);
                string propertyName = reader.Value.ToString();
                reader.Read();
                values.Add(propertyName, reader.Value);
                reader.Read();
            }
            source = values;
        }
        else
            throw new FormatException("Expected start of object or start of array");
        reader.Read();
        return source;
    }
