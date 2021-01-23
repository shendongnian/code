    System.Reflection.PropertyInfo propInfo = 
        theObjectYouWantToReflect.GetType().GetProperty("YourPropertyName");
    if (propInfo != null)
    {
        object value = propInfo.GetValue(Page, null);
        // ...
    }
