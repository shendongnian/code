    public class EmailConverterTest : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(EmailAddress);
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            EmailAddress actualAddress =  new EmailAddress(reader.Value.ToString());
            
            return actualAddress;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            EmailAddress actualAddress = (EmailAddress)value;
            string stringEmail = actualAddress.ToString();
            writer.WriteValue(stringEmail);
        }
    }
