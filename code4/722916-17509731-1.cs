    public class ResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(IResponse));
        }
        
        public override object ReadJson(JsonReader reader,
                                        Type objectType,
                                        object existingValue,
                                        JsonSerializer serializer)
        {
            // reader is forward only so we need to parse it
            var jObject = JObject.Load(reader);
            reader = jObject.CreateReader();
            
            if(jObject["user"] != null) // check if response is user
            {
                var user = serializer.Deserialize<UserResponse>(reader);
                return user;
            }
            
            if(jObject["venues"] != null) // check if response if venues
            {
                var venue = serializer.Deserialize<VenuesResponse>(reader);
                return venue;
            }
            
            throw new NotImplementedException("This reponse type is not implemented");
        }
        
        public override void WriteJson(JsonWriter writer,
                                       object value,
                                       JsonSerializer serializer)
        {
            // Left as an exercise to the reader :)
            throw new NotImplementedException();
        }
    }
    
