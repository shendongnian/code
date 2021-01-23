    class WidgetPropsConverter : JsonConverter
    {
        public override void WriteJson(
            JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue,
            JsonSerializer serializer)
        {
            var array = serializer.Deserialize<object[]>(reader);
            return new WidgetProps
            {
                Visible = (bool)array[0],
                DockState = (string)array[1],
                Zone = (string)array[2],
                Top = (string)array[3],
                Left = (string)array[4],
                Position = (int)(long)array[7]
            };
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(WidgetProps);
        }
    }
