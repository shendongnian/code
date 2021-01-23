    public object Eval(object root, string propertyString)
    {
        var propertyNames = propertyString.Split('.');
        foreach(var prop in propertyNames)
        {
            var property = root.GetType().GetProperty(prop);
            if (property == null)
            {
                throw new Exception(...);
            }
            root = property.GetValue(root, null);
        }
    
        return root;
    }
