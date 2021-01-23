    public static string SerializeObject(object obj, int maxDepth)
    {
        using (var strWriter = new StringWriter())
        {
            var currentDepth = 0;
            Action<bool> adjustDepth = dir => currentDepth += (dir ? 1 : -1);
            Func<bool> includeProperty = () => currentDepth <= maxDepth;
            using (var jsonWriter = new CustomJsonTextWriter(strWriter, adjustDepth))
            {
                var resolver = new CustomContractResolver(includeProperty);
                var serializer = new JsonSerializer {ContractResolver = resolver};
                serializer.Serialize(jsonWriter, obj);
            }
            return strWriter.ToString();
        }
    }
