    public dynamic GetFlatExpando(object o)
    {
        IDictionary<string, object> result = new ExpandoObject();
        
        foreach(var property in o.GetType().GetProperties())
        {
            var value = property.GetValue(o, null);
            var expando = value as ExpandoObject;
            if(expando == null)
                result[property.Name] = value;
            else
                expando.CopyInto(result);
        }
        
        return result;
    }
    
    public static class Extensions
    {
        public static void CopyInto(this IDictionary<string, object> source,
                                    IDictionary<string, object> target)
        {
            foreach(var member in source)
            {
                target[member.Key] = member.Value;
            }
        }
    }
