    GetPropertyName<MemoryDevice>(x => x.DeviceLocator)
    public static string GetPropertyName<TClass>(
            Expression<Func<TClass,object>> propertyExpression)
        {
            var body = propertyExpression.ToString();
            body = body.Substring(body.IndexOf(".")+1);
            return body;
        }
