    public class StringToObjectConverter : JsonConverter
    {
       public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
       {
           JObject root = JObject.Parse(value.ToString());
    		
    		serializer.Serialize(writer, root);
       }
    
       public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
       {
           throw new NotImplementedException();
       }
    
       public override bool CanConvert(Type objectType)
       {
           return true;
       }
    }
