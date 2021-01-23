    public abstract class CustomJsonConverter<T, TResult> : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load token from stream
            var token = JToken.Load(reader);
            // Create target object based on token
            var target = Create(objectType, token);
            var targetType = target.GetType();
            if (targetType.IsClass && targetType != typeof(string))
            {
                // Populate the object properties
                var tokenReader = token.CreateReader();
                CopySerializerSettings(serializer, tokenReader);
                serializer.Populate(token.CreateReader(), target);
            }
            return target;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            T typedValued = (T)value;
            TResult valueToSerialize = Convert(typedValued);
            serializer.Serialize(writer, valueToSerialize);
        }
        public override bool CanConvert(Type objectType)
        {
            return typeof (T) == objectType;
        }
        protected virtual T Create(Type type, JObject jObject)
        {
            // reads the token as an object type
            if (typeof(TResult).IsClass && typeof(T) != typeof(string))
            {
                return Convert(token.ToObject<TResult>());
            }
            var simpleValue = jObject.Value<TResult>();
            return Convert(simpleValue);
        }
        protected abstract TResult Convert(T value);
        protected abstract T Convert(TResult value);
        private static void CopySerializerSettings(JsonSerializer serializer, JsonReader reader)
        {
            reader.Culture = serializer.Culture;
            reader.DateFormatString = serializer.DateFormatString;
            reader.DateTimeZoneHandling = serializer.DateTimeZoneHandling;
            reader.DateParseHandling = serializer.DateParseHandling;
            reader.FloatParseHandling = serializer.FloatParseHandling;
        }
    }
