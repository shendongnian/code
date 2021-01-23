    using System.Reflection;  // reflection namespace
     // get all public static properties of MyClass type
    PropertyInfo[] propertyInfos;
    
     foreach (Control cntrl in Panel1.Controls)
    {
    
    
    if( cntrl is TextBox)
    {
   
    propertyInfos = typeof(TextBox).GetProperties(BindingFlags.Public |
                                                  BindingFlags.Static);
    //Loop thru property info n find the name using PropertyInfo.Name
     if(property.Name == "property name")
      //assign values
    }
    else 
    { 
        //others
    }
    
    
    }
