    public class MyStringEnumConverter : Newtonsoft.Json.Converters.StringEnumConverter
    {
          public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
          {
              if (value.GetType().IsEnum)
              {
                  writer.WriteValue(Enum.GetName(value.GetType(), value));
                  return;
              }
                  base.WriteJson(writer, value, serializer);
          }
    }
