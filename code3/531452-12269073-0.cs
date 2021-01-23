    System.Attribute[] attrs = System.Attribute.GetCustomAttributes(Person);  // Reflection. 
    
    // Displaying output. 
    foreach (System.Attribute attr in attrs)
    {
         System.Console.WriteLine(attr);
    }
