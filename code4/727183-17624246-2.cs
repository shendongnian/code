    private void SetValue(object source, String path, String value)
    {
        if (path.Contains('.'))
        {
            //  If this is not the ending Property, continue recursing
            int index = path.IndexOf('.');
            String property = path.Substring(0, index);
    
            object nextSource;
            if(property[0] = '*')
            {
                path = path.Substring(index + 1);
                index = path.IndexOf('.');
                String dictionaryName = path.Substring(0, index);
                property = property.Substring(1);
    
                Object list = source.GetType().GetProperty(dictionaryName)
                                    .GetValue(source, null);
                nextSource = list.GetType().GetProperty("Item")
                                 .GetValue(list, new[] { property });
            }
