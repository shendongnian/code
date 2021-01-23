    public static dynamic GetDynamicObject(Dictionary<string,object> properties) {
        var dynamicObject = new ExpandoObject() as IDictionary<string, Object>;
        foreach (var property in properties) {
            dynamicObject.Add(property.Key,property.Value);
        }
        return dynamicObject;
    }
