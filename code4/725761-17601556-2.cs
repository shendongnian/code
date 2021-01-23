    public class RawJsonConverter : JsonConverter
    {
       public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
       {
           writer.WriteRawValue(value.ToString());
       }
    
       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
       {
           throw new NotImplementedException();
       }
    
       public override bool CanConvert(Type objectType)
       {
           return typeof(string).IsAssignableFrom(objectType);
       }
       
       public override bool CanRead
       {
           get { return false; }
       }   
    }
