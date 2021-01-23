    public class DoubleConverter : JsonConverter
    {
        public override bool CanWrite
        {
            get { return false; }
        }
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(double) || objectType == typeof(double?));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Float || token.Type == JTokenType.Integer)
            {
                return token.ToObject<double>();
            }
            if (token.Type == JTokenType.String)
            {
                // customize this to suit your needs
                var wantedSeperator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
                var alternateSeparator = wantedSeperator == "," ? "." : ",";
                double actualValue;
                if (double.TryParse(token.ToString().Replace(alternateSeparator, wantedSeperator), NumberStyles.Any,
                    CultureInfo.CurrentCulture, out actualValue))
                {
                    return actualValue;
                }
                else
                {
                    throw new JsonSerializationException("Unexpected token value: " + token.ToString());
                }
            }
            if (token.Type == JTokenType.Null && objectType == typeof(double?))
            {
                return null;
            }
            if (token.Type == JTokenType.Boolean)
            {
                return token.ToObject<bool>() ? 1 : 0;
            }
            throw new JsonSerializationException("Unexpected token type: " + token.Type.ToString());
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("Unnecessary because CanWrite is false. The type will skip the converter.");
        }
    }
