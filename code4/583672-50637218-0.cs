    public static class ObjectExtension
    {
        public static ExpandoObject ToExpando(this object source)
        {
            IDictionary<string, object> anonymousDictionary = new RouteValueDictionary(source);
            IDictionary<string, object> expando = new ExpandoObject();
            foreach (var item in anonymousDictionary)
                expando.Add(item);
            return (ExpandoObject)expando;
        }
    }
