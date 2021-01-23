        class UnixDateJsonConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(UnixDateTime));
            }
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                // I'll figure this out later
                throw new NotImplementedException();
            }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                if (value == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                UnixDateTime dt = (UnixDateTime)value;
                serializer.Serialize(writer, (int) dt);
            }
        }
