    class EntityGroupConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Group);
        }
        public override object ReadJson(JsonReader reader, Type objectType,
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override void WriteJson(JsonWriter writer, object value,
            JsonSerializer serializer)
        {
            Group group = value as Group;
            serializer.Serialize(writer, new { ID = group.ID,
                GroupOrganisation = new { ID = group.Organisation.ID } });
        }
    }
