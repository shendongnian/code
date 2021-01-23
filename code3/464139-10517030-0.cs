    class PersonConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            var person = (Person)value;
            serializer.Serialize(
                writer,
                new
                {
                    Name = person.LastName,
                    Age = (int)(DateTime.Now - person.BirthDate).TotalDays / 365
                });
        }
        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Person);
        }
    }
