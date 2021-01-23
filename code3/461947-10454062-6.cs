    public static string SerializeObject(object obj, int maxDepth)
    {
        using (var strWriter = new StringWriter())
        {
            using (var jsonWriter = new CustomJsonTextWriter(strWriter))
            {
                Func<bool> include = () => jsonWriter.CurrentDepth <= maxDepth;
                var resolver = new CustomContractResolver(include);
                var serializer = new JsonSerializer {ContractResolver = resolver};
                serializer.Serialize(jsonWriter, obj);
            }
            return strWriter.ToString();
        }
    }
