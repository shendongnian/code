    public class MyConverter : Newtonsoft.Json.Converters.StringEnumConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(FeedType);
        }
        
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var field = objectType.GetFields()
                .First(f => f.GetCustomAttributes(false)
                             .Any(a=>a.GetType()==typeof(EnumMemberAttribute) &&
                                     ((EnumMemberAttribute)a).Value.Equals(reader.Value))); 
                
            return field.GetValue(null);
        }
    }
