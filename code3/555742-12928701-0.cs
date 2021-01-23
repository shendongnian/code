    string[] dateStrings = {"05/01/2009 14:57:32.8", "2009-05-01 14:57:32.8", 
                            "2009-05-01T14:57:32.8375298-04:00", 
                            "5/01/2008 14:57:32.80 -07:00", 
                            "1 May 2008 2:57:32.8 PM", "16-05-2009 1:00:32 PM", 
                            "Fri, 15 May 2009 20:10:57 GMT" };
    DateTime dateValue;
    
    Console.WriteLine("Attempting to parse strings using {0} culture.", 
                      CultureInfo.CurrentCulture.Name);
    foreach (string dateString in dateStrings)
    {
       if (DateTime.TryParse(dateString, out dateValue)) 
          Console.WriteLine("  Converted '{0}' to {1} ({2}).", dateString, 
                            dateValue, dateValue.Kind);
       else
          Console.WriteLine("  Unable to parse '{0}'.", dateString);
    }
