    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        //JToken t = JToken.FromObject(value); // do not use this! leads to stack overflow
        JsonObjectContract contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());
        writer.WriteStartObject();
        writer.WritePropertyName(value.GetType().Name);
        writer.WriteStartObject();
        foreach (var property in contract.Properties)
        {
            // this removes any property with null value
            var propertyValue = property.ValueProvider.GetValue(value);
            if (propertyValue == null) continue;
            writer.WritePropertyName(property.PropertyName);
            serializer.Serialize(writer, propertyValue);
            //writer.WriteValue(JsonConvert.SerializeObject(property.ValueProvider.GetValue(value))); // this adds escaped quotes
        }
        writer.WriteEndObject();
        writer.WriteEndObject();
    }
