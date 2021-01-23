      public class UserConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var user = (User)value;
            var result = new StringBuilder("{");
            result.Append("title : " + user.GetType().Name + ", ");
            result.Append("properties : {");
            foreach (var prop in user.GetType().GetProperties())
            {
                result.Append(prop.Name + ": {");
                result.Append("value : " + Convert.ToString(prop.GetValue(user, null)) + ", ");
                var attribute = (JsonPropertyAttribute)Attribute.GetCustomAttributes(prop)[0];
                if (attribute.Required == Required.Always)
                    result.Append("required : true, ");
                result.Append("type : " + prop.PropertyType.Name.ToLower());
                result.Append(" }");
            }
            writer.WriteValue(result.ToString());
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var user = new User { UserName = (string)reader.Value };
            return user;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(User);
        }
    }
---
    [JsonConverter(typeof(UserConverter))]
    public class User
    {
        [JsonProperty(Required = Required.Always)]
        public string UserName { get; set; }
    }
    //Run  
    string json = JsonConvert.SerializeObject(manager, Formatting.Indented);
            
    Console.WriteLine(json);
