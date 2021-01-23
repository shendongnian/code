    public class Vector2Converter : JsonConverter {
      public override bool CanConvert(Type objectType) {
        return (objectType == typeof(Vector2));
      }
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
        return serializer.Deserialize<Vector2>(reader);
      }
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)  {
        // Implement this if you're serialising back into JSON
        throw new NotImplementedException();
      }
    }
