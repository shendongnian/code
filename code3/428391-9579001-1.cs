    public static class JavaScriptSerializerExtension
    {
        public static dynamic DeserializeDynamic(this JavaScriptSerializer serializer, string value)
        {
            var dic = serializer.Deserialize<IDictionary<string, object>>(value);
            return ToExpando(dic);
        }
    
        private static ExpandoObject ToExpando(IDictionary<string, object> dic)
        {
            var expando = new ExpandoObject() as IDictionary<string, object>;
                
            foreach (var item in dic)
            {
                var prop = item.Value as IDictionary<string, object>;
                expando.Add(item.Key, prop == null ? item.Value : ToExpando(prop));
            }
    
            return (ExpandoObject)expando;
        }
    }
