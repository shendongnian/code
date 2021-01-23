     private static void ConvertToDateTime(string value)
     {
      DateTime convertedDate;
      try {
         convertedDate = Convert.ToDateTime(value);
         Console.WriteLine("'{0}' converts to {1} {2} time.", 
                           value, convertedDate, 
                           convertedDate.Kind.ToString());
      }
      catch (FormatException) {
         Console.WriteLine("'{0}' is not in the proper format.", value);
      }
    }
