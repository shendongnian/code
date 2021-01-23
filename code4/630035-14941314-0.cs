    var type = Type.GetType("System.Web.Helpers.DynamicJavaScriptConverter, System.Web.Helpers");
    var converter = (JavaScriptConverter)Activator.CreateInstance(type);
    JavaScriptSerializer serializer = new JavaScriptSerializer();
    serializer.RegisterConverters(new[] { converter });
    var json = serializer.Serialize(obj);
