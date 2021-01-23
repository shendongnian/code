    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        serializer.Converters.Remove(this);
        serializer.Serialize(writer, value);
        serializer.Converters.Add(this);
    }
