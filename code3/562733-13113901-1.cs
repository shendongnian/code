    class JsonLinkedContext
    {
        private readonly IDictionary<Type, IDictionary<string, object>> links = new Dictionary<Type, IDictionary<string, object>>();
        public static object GetLinkedValue (JsonSerializer serializer, Type type, string reference)
        {
            var context = (JsonLinkedContext)serializer.Context.Context;
            IDictionary<string, object> links;
            if (!context.links.TryGetValue(type, out links))
                context.links[type] = links = new Dictionary<string, object>();
            object value;
            if (!links.TryGetValue(reference, out value))
                links[reference] = value = FormatterServices.GetUninitializedObject(type);
            return value;
        }
    }
