    foreach (PropertyInfo propertyInfo in obj1.GetType().GetProperties())
    {
        //If property is public
        if (propertyInfo.CanRead)
        {
            object propValue = propertyInfo.GetValue(obj1, null);
            System.Console.WriteLine(propValue.ToString());
        }
    }
    
