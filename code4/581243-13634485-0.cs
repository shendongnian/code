    public IDictionary<string, object> GetEntities(string entityName, string entityField)
        {
           var serializer = new JavaScriptSerializer();
            serializer.RegisterConverters(new[] { new MyProject.Extensions.JsonExtension.DynamicJsonConverter() });
           dynamic data = serializer.Deserialize(json, typeof(object));
           return data as IDictionary<string, object>;
        }
 
    foreach (var author in GetEntities("author", "lastname"))
