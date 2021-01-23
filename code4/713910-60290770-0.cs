cs
public static ContentResult CamelJson<TData>(TData response)
{
    DefaultContractResolver resolver = new CamelCasePropertyNamesContractResolver();
    JsonSerializerSettings settings = new JsonSerializerSettings
    {
        ContractResolver = resolver,
        DateFormatHandling = DateFormatHandling.IsoDateFormat
    };
    return new ContentResult
    {
        Content = JsonConvert.SerializeObject(response, settings),
        ContentType = "application/json"
    };
}
Example usage:
cs
[HttpGet]
public ContentResult GetCamelCaseJsonData()
{
  return ContentUtils.CamelJson(result);
}
The output will be camel-case.
