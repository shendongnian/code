    static void ContainingMethod()
    {
      var anondata = new
      {
        IntegerVal = 1,
        DoubleVal = 2.0D,
        DateTimeVal = DateTime.Now,
        StringVal = "some string"       
      };
    
      ExternalMethod(anondata);
    }
    
    static void ExternalMethod(object data)
    {
      // Get the type that was passed in
      Type t = data.GetType();
      // Get a list of the properties
      PropertyInfo[] piList = t.GetProperties();
      // Loop through the properties in the list
      foreach (PropertyInfo pi in piList)
      {
        // Get the value of the property
        object o = pi.GetValue(data, null);
        // Write out the property information
        Console.WriteLine("{0} ({1}): \t{2}", pi.Name, o.GetType(), o.ToString());
      }
    }
