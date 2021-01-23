        public class CustomConverter : JsonConverter
        {
            public CustomConverter()
            {
                
                
            }
            public override bool CanWrite
            {
                get { return false; }
            }
            private static readonly CustomConverter _instance = new CustomConverter();
            public static CustomConverter Instance
            {
                get { return _instance; }
            }
            public override bool CanConvert(Type objectType)
            {
                return (objectType.IsAssignableFrom(typeof(MultilingualValue<MultilingualValueMetaData<string>>)));
                
            }
               public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
               {
                   MultilingualValue<MultilingualValueMetaData<string>> result = new MultilingualValue<MultilingualValueMetaData<string>>();
                   JsonToken firstToken = reader.TokenType;
                   reader.Read();//skip first Token
                   while (reader.TokenType != JsonToken.EndObject)
                   {
                       string languageType = (string) reader.Value;
                       reader.Read();
                       MultilingualValueMetaData<string> metaData = null;
                       if (reader.TokenType == JsonToken.StartObject)
                       {
                           metaData = serializer.Deserialize<MultilingualValueMetaData<string>>(reader);
                       }
                       else
                       {
                           metaData = new MultilingualValueMetaData<string>();
                           metaData.AutoTranslation = (string) reader.Value;
                          
                       }
                       result[languageType] = metaData;
                       reader.Read();
                   }
                   return result;
               }
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                
                
                
            }
        }
