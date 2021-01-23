    public class DocumentEntryCreationConverter : CustomCreationConverter<Document.Entry>
    {
        public override Document.Entry Create(Type objectType)
        {
            return new Document.Entry();
        }
    
        public override object ReadJson(
            JsonReader reader, 
            Type objectType,
            object existingValue, 
            JsonSerializer serializer)
        {
            // If this is not an object - looks like an old format
            // So we need only set a value
            if (reader.TokenType == JsonToken.String) 
            {
                Document.Entry entry = this.Create(objectType);
                entry.Value = reader.Value as string;
                return entry;
            }
            else
            {
                // This is new format, we can recognise it as an object
                Debug.Assert(
                    reader.TokenType == JsonToken.StartObject, 
                    "reader.TokenType == JsonToken.StartObject");
                return base.ReadJson(reader, objectType, existingValue, serializer);
            }
        }
    }
