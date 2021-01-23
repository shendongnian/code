    using System;
    using System.Globalization;
    public class Example
    {
          public static void Main()
       {
          DateTimeFormatInfo myDTFI = new CultureInfo("en-US", false).DateTimeFormat;
    
          char[] formats = { 'd', 'D', 'f', 'F', 'g', 'G', 'm', 'o', 
                               'r', 's', 't', 'T', 'u', 'U', 'y' };
          DateTime date1 = new DateTime(2011, 02, 01, 7, 30, 45, 0);
          DateTime date2;
    
          foreach (var fmt in formats) 
          {
             foreach (var pattern in myDTFI.GetAllDateTimePatterns(fmt))
             {
                // "round-trip" = convert the date to string, then parse it
                if (DateTime.TryParse(date1.ToString(pattern), out date2))
                {
                    Console.WriteLine("{0:" + pattern + "} (format '{1}')",
                                      date1, pattern);
                }
             }
          }
       }
    }
 
