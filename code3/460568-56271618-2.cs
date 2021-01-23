public static string ToEnumString<T>(T value)
{
   return JsonConvert.SerializeObject(value).Replace("\"", "");
}
public static T ToEnum<T>(string value)
{
   return JsonConvert.DeserializeObject<T>($"\"{value}\"");
}
The `ToEnumString` method will only work if you have the `StringEnumConverter` registered in your `JsonSerializerSettings` (see https://stackoverflow.com/questions/2441290/net-json-serialization-of-enum-as-string), e.g.
JsonConvert.DefaultSettings = () => new JsonSerializerSettings
{
    Converters = { new StringEnumConverter() }
};
Another advantage of this method is that if only some of your enum elements have the member attribute, things still work as expected, e.g.
public enum CarEnum
{
    Ford,
    Volkswagen,
    [EnumMember(Value = "Aston Martin")]
    AstonMartin
}
  [1]: https://www.nuget.org/packages/Newtonsoft.Json/
