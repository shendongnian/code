    class Program
    {
        static void Main(string[] args)
        {
            var cfUser = new CFUser(1, @"{""test"":""ok""}");
            var json = JsonConvert.SerializeObject(cfUser);
            var deserialized = JsonConvert
                .DeserializeObject(json, typeof(CFUser));
        }
    }
    class UserPreferencesConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(
            JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
        {
            var jObject = JObject.Load(reader);
            return jObject.ToString()
                .Where(c => !"\r\n ".Contains(c))
                .Aggregate<char, string>("", (s, c) => s + c);
        }
        public override void WriteJson(JsonWriter writer, 
            object value, JsonSerializer serializer)
        {
            writer.WriteRawValue(value.ToString());
        }
    }
    public class CFUser
    {
        public int UserId { get; private set; }
        [JsonProperty(PropertyName = "UserPreferences")]
        [JsonConverter(typeof(UserPreferencesConverter))]
        public string UserPreferences { get; private set; }
        public CFUser(Int32 userId, string userPreferences)
        {
            UserId = userId;
            UserPreferences = userPreferences;
        }
    }
