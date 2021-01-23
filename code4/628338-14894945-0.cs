    internal class TestObjectConverter : CustomCreationConverter<Test>
    {
        #region Overrides of CustomCreationConverter<Test>
        public override Test Create(Type objectType)
        {
            return new Test
                {
                    Y = new Dictionary<string, string>()
                };
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            // Write properties.
            var propertyInfos = value.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                // Skip the Y property.
                if (propertyInfo.Name == "Y")
                    continue;
                writer.WritePropertyName(propertyInfo.Name);
                var propertyValue = propertyInfo.GetValue(value);
                serializer.Serialize(writer, propertyValue);
            }
            // Write dictionary key-value pairs.
            var test = (Test)value;
            foreach (var kvp in test.Y)
            {
                writer.WritePropertyName(kvp.Key);
                serializer.Serialize(writer, kvp.Value);
            }
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject jsonObject = JObject.Load(reader);
            var jsonProperties = jsonObject.Properties().ToList();
            var outputObject = Create(objectType);
            // Property name => property info dictionary (for fast lookup).
            var propertyNames = objectType.GetProperties().ToDictionary(pi => pi.Name, pi => pi);
            foreach (var jsonProperty in jsonProperties)
            {
                // If such property exists - use it.
                PropertyInfo targetProperty;
                if (propertyNames.TryGetValue(jsonProperty.Name, out targetProperty))
                {
                    var propertyValue = jsonProperty.Value.ToObject(targetProperty.PropertyType);
                    targetProperty.SetValue(outputObject, propertyValue, null);
                }
                else
                {
                    // Otherwise - use the dictionary.
                    outputObject.Y.Add(jsonProperty.Name, jsonProperty.Value.ToObject<string>());
                }
            }
            return outputObject;
        }
        public override bool CanWrite
        {
            get { return true; }
        }
        #endregion
    }
