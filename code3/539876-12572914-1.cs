    public class ResourceConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Resource));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            List<string> properties = new List<string>(new string[] { "Name", "Label" });
            writer.WriteStartObject();
            foreach (MemberInfo mi in value.GetType().GetMembers(BindingFlags.GetField | BindingFlags.Instance | BindingFlags.Public) )
            {
                PropertyInfo p = mi as PropertyInfo;
                if (p != null && p.GetCustomAttributes(typeof(JsonIgnoreAttribute), true).Length == 0 && properties.Contains(p.Name))
                {
                    writer.WritePropertyName(p.Name);
                    serializer.Serialize(writer, p.GetValue(value, new object[] { }));
                }
            }
            writer.WriteEndObject();
        }
    }
