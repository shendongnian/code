    public static class NameValueCollectionExtensions:
    {
        public static dynamic ToExpando(this NameValueCollection valueCollection)
        {
            var result = new ExpandoObject() as IDictionary<string, object>;
            foreach (var key in valueCollection.AllKeys)
            {
                result.Add(key, valueCollection[key]);
            }
            return result;
        }
    }
