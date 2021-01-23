    private class JsonEnumTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsEnum;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                var value = Enum.Parse(objectType, reader.Value.ToString(), true);
                if (IsFlagDefined((Enum)value))
                {
                    return value;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value);
        }
        private static bool IsFlagDefined(Enum e)
        {
            decimal d;
            return (!decimal.TryParse(e.ToString(), out d));
        }
    }
