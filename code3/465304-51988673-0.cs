    MyClass myObject = new MyClass();
    myObject.propA = "string Value";
    var response = EncodeProperties(myObject.getType(),myObject);
    myObject = response as myObject ;
        public static object EncodeProperties(Type type, object obj)
        {
            var propertiesInfo = type.GetProperties();
            foreach (PropertyInfo p in propertiesInfo)
            {
                if (p.PropertyType.IsPrimitive
                    && p.PropertyType.FullName == "System.String")               
                {
                        p.SetValue(obj, HttpUtility.HtmlEncode(value), null);
                    
                }
            }
            return obj;
        }
