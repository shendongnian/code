    public override void WriteJson(JsonWriter writer, object value,
        JsonSerializer serializer)
    {
        if (CanConvert(value.GetType()))
        {
            FakeMyResponse response = new FakeMyResponse((MyResponse)value);
            serializer.Serialize(writer, response);
        }
    }
