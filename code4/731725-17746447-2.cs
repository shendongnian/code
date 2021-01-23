    public class UserRolesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (Role[]);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return serializer.Deserialize<JObject>(reader)
                             .Properties()
                             .Select(p => new Role
                                 {
                                     Id = Int32.Parse(p.Name),
                                     Name = (string) p.Value["name"]
                                 })
                             .ToArray();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    public class User
    {
        public string Name { get; set; }
        [JsonConverter(typeof(UserRolesConverter))]
        public Role[] Roles { get; set; }
    }
    var jsonUser = JsonConvert.DeserializeObject<User>(json);
