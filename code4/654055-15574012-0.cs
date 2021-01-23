    // this line may need adjusting depending on whether the method you're calling is static
    MethodInfo readMethod = typeof(DataReader).GetMethod("Read"); 
    foreach (PropertyInfo info in type1.GetProperties())
    {
        // get a "closed" instance of the generic method using the required type
        MethodInfo genericReadMethod m.MakeGenericMethod(new Type[] { info.PropertyType });
        // invoke the generic method
        object value = genericReadMethod.Invoke(info.Name, reader);
        info.SetValue(item, value, null);
    }
    
    
