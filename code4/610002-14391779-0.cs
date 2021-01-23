using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
    var objToSerialize = new Object();
    
    var settings = new JsonSerializerSettings();
    settings.Converters.Add(new StringEnumConverter());
    
    var serializer = JsonSerializer.Create(settings);
    
    var sb = new StringBuilder();
    using (var sw = new StringWriter(sb))
    {
        serializer.Serialize(sw, objToSerialize);
    }
    
    string json = sb.ToString();
