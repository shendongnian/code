    Type dictionary = typeof(Dictionary<,>);
    Type[] typeArgs = info.PropertyType.GetGenericArguments();
    
    // Construct the type Dictionary<T1, T2>.
    Type constructed = dictionary.MakeGenericType(typeArgs);
    IDictionary newDictionary = (IDictionary)Activator.CreateInstance(constructed);
    
    // Populating the dictionary here from file. insert only typed values below
    newDictionary.Add(new object(), new object());
   
    info.SetValue(data, newDictionary, null);
