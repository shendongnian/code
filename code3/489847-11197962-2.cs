    public static List<string> ReflectObject(object o)
    {
        var items = new List<string>();
    
        if (o == null)
        {
            items.Add("NULL"); // remove if you're not interested in NULLs.
            return items;
        }
    
        Type type = o.GetType();
    
        if (type.IsPrimitive || o is string)
        {
            items.Add(o.ToString());
            return items;
        }
        items.Add(string.Format("{0}{1}{0}", " ----- ", type.Name));
        if (o is IEnumerable)
        {
            IEnumerable collection = (IEnumerable)o;
            var enumerator = collection.GetEnumerator();
    
            while (enumerator.MoveNext())
            {
                foreach (var innerItem in ReflectObject(enumerator.Current))
                {
                    items.Add(innerItem);
                }
            }
        }
        else
        {
            var properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
    
            foreach (var property in properties)
            {
                object value = property.GetValue(o, null);
    
                foreach (var innerItem in ReflectObject(value))
                {
                    items.Add(string.Format("{0}: {1}", property.Name, innerItem));
                }
            }
        }
    
        return items;
    }
