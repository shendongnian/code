    .....
    dynamic myExpandoObject = new ExpandoObject();
    var result = ConvertDynamic<myType>(myExpandoObject);
    .....
        public T ConvertDynamic<T>(IDictionary<string, object> dictionary)
        {
            var jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            var obj = jsSerializer.ConvertToType<T>(dictionary);
            return obj;
        }
