    class RolesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Role[]);
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // deserialize as object
            var roles = serializer.Deserialize<JObject>(reader);
            var result = new List<Role>();
            
            // create an array out of the properties
            foreach (JProperty property in roles.Properties())
            {
                var role = property.Value.ToObject<Role>();
                role.Id = int.Parse(property.Name);
                result.Add(role);
            }
            
            return result.ToArray();
        }
    
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
