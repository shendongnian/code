    class StructConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            var myObject = (object)value;
            var jObject = new JObject();
            Type myType = myObject.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());
            foreach (PropertyInfo prop in props)
            {
                jObject.Add(prop.Name, prop.GetValue(myObject, null).ToString());
            }
            serializer.Serialize(
                writer,  jObject);
        }..
    }
