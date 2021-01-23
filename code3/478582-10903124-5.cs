    public class UriConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                //try to create uri out of the string
                Uri uri;
                if(Uri.TryCreate(reader.Value.ToString(), UriKind.Absolute, out uri))
                {
                    return uri;
                }
                //just a string -> return string value
                return reader.Value;
            }
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }
            throw new InvalidOperationException("Unable to process JSON");
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (null == value)
            {
                writer.WriteNull();
                return;
            }
            if (value is Uri)
            {
                writer.WriteValue(((Uri)value).OriginalString);
                return;
            }
            throw new InvalidOperationException("Unable to process JSON");
        }
    }
