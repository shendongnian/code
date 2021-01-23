    foreach (var prop in myobject.GetType().GetProperties(BindingFlags.Public|BindingFlags.Instance))
    {
       var propertyName = prop.Name;
       var propertyValue = myobject.GetType().GetProperty(propertyName).GetValue(myobject, null);
       
       //Debug.Print(prop.Name);
       //Debug.Print(Functions.convertNullableToString(propertyValue));
        
       Debug.Print(string.Format("Property Name={0} , Value={1}", prop.Name, Functions.convertNullableToString(propertyValue)));
    }
