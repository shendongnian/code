    private void SetValue(object source, String path, String value)
    {
        if (path.Contains('.'))
        {
            //  If this is not the ending Property, continue recursing
            int index = path.IndexOf('.');
            String property = path.Substring(0, index);
    
            object nextSource;
            if(property.Contains("*"))
            {
                path = path.Substring(index + 1);
                index = path.IndexOf('.');
                String dictionaryName = path.Substring(0, index);
                property = property.Substring(1);
    
                IDictionary list = source.GetType().GetProperty(dictionaryName).GetValue(source, null) as IDictionary;
                if (!list.Contains(property))
                {
                    Type[] arguments = list.GetType().GetGenericArguments();
                    list.Add(property, Activator.CreateInstance(arguments[1]));
                }
    
                nextSource = list[property];                    
            }
            else
                nextSource = source.GetType().GetProperty(property).GetValue(source, null);
    
            SetValue(nextSource, path.Substring(index + 1), value);
        }
        else
        {
            PropertyInfo pi = source.GetType().GetProperty(path);
            pi.SetValue(source, Convert.ChangeType(value, pi.PropertyType), null);
        }
    }
