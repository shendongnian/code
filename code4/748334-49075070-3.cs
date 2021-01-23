    class MyListConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var list = Activator.CreateInstance(objectType) as System.Collections.IList;
            var itemType = objectType.GenericTypeArguments[0];
            foreach (var child in token.Values())
            {
                var childToken = child.Children().First();
                var newObject = Activator.CreateInstance(itemType);
                serializer.Populate(childToken.CreateReader(), newObject);
                list.Add(newObject);
            }
            return list;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsGenericType && (objectType.GetGenericTypeDefinition() == typeof(List<>));
        }
        public override bool CanWrite => false;
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();
    }
