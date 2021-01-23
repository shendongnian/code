    Dictionary<string, object> dictionary = ...;
    
    
    private void AddAssignable(object assignableObject)
    {
         var type = assignableObject.GetType();
         if (type.GetCustomAttributes(typeof(AssignableAttribute), true) == null)
            return;
    
         dictionary.Add(type.Name, assignableObject);
    }
