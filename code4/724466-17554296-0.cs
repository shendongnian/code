    public class MyDateTimeConverter : DateTimeConverterBase
    {
            public override void WriteJson(JsonWriter writer,
                                               object value,
                                                      JsonSerializer serializer)
            {
                writer.WriteValue(((DateTime)value)
                                   .ToString("yyyy-MM-ddTHH:mm:ss"));
            }
    }
