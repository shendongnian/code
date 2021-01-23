    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        if (object is INotSerializableDontEvenTry)
        {
            INotSerializableDontEvenTry dontEvenTry = (INotSerializableDontEvenTry) object;
            writer.WriteStartObject();
            writer.WritePropertyName(dontEvenTry.Name);
            serializer.Serialize(writer, dontEvenTry.Value);
            writer.WriteEndObject();
        }
        else
        {
            base.WriteJson(writer, value, serializer);
        }
    }
