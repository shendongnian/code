    foreach (PropertyInfo info in myObject.GetType().GetProperties())
    {
       if (info.CanRead)
       {
          object o = propertyInfo.GetValue(myObject, null);
       }
    }
    
    To Set  value
    ================
    
    object myValue = "Something";
    if (propertyInfo.CanWrite)
    {
        this.propertyInfo.SetValue(myObject, myValue, null);
    }
