    [Flags]
    enum FlagEnumerable
    {
        Flag1 = 1,
        Flag2 = 2,
        Flag3 = 4
    }
    class FlagsEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum && objectType.GetCustomAttributes(typeof(FlagsAttribute), false).Any();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var values = serializer.Deserialize<string[]>(reader);
    
            return values
                .Select(x => Enum.Parse(objectType, x))
                .Aggregate(0, (current, value) => current | (int) value);
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var enumArr = Enum.GetValues(value.GetType())
                .Cast<int>()
                .Where(x => (x & (int) value) == x)
                .Select(x => Enum.ToObject(value.GetType(), x).ToString())
                .ToArray();
    
            serializer.Serialize(writer, enumArr);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>() {new FlagsEnumConverter()}
            };
    
            var targetObj = new { MyField = FlagEnumerable.Flag1 | FlagEnumerable.Flag3 };
            var str = JsonConvert.SerializeObject(targetObj);
            var deserializedObj = JsonConvert.DeserializeObject(str, targetObj.GetType());
        }
    }
