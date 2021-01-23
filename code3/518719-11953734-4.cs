    class IntPropertyConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            // this converter can be applied to any type
            return true;
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // we currently support only writing of JSON
            throw new NotImplementedException();
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
        
            // find all properties with type 'int'
            var properties = value.GetType().GetProperties().Where(p => p.PropertyType == typeof(int));
            
            writer.WriteStartObject();
            
            foreach (var property in properties)
            {
                // write property name
                writer.WritePropertyName(property.Name);
                // let the serializer serialize the value itself
                // (so this converter will work with any other type, not just int)
                serializer.Serialize(writer, property.GetValue(value, null));
            }
            
            writer.WriteEndObject();
        }
    }
