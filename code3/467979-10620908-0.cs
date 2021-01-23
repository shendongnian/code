    var accessor = TypeAccessor.Create(typeof(T)); 
    for (int i = 0; reader.Read(); i++)
    {
        T tmp = (T)Activator.CreateInstance(typeof(T));
        foreach (var prop in properties)
        {         
            accessor[tmp, propName] = newValue; // fill in name/value here
        }
    }
