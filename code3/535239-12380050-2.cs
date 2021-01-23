    public static class JSONExtensions
    {
        public static IDictionary<string, object> ToJsonObject(this object instance, string[] includedProperties)
        {
            var jsonObject = new Dictionary<string, object>();
            foreach (var property in instance.GetType().GetProperties())
            {
                if (includedProperties.Any(x=> x.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                {
                    jsonObject[property.Name] = property.GetValue(instance);
                }
            }
            return jsonObject;
        }
    }
