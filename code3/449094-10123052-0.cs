    using System;
    using System.Globalization;
    
    public class Test
    {
        static void Main()
        {
            string inputDateString = "01/01/2012 23:36:17.234";
            string inputFormat = "dd/MM/yyyy HH:mm:ss.fff";        
            string outputFormat = "yyyy/MM/dd HH:mm:ss.fff";
            
            DateTime parsed = DateTime.ParseExact(inputDateString, inputFormat,
                                                  CultureInfo.InvariantCulture,
                                                  DateTimeStyles.AssumeLocal);
            string outputDateString = parsed.ToString(outputFormat, 
                                                      CultureInfo.InvariantCulture);
            Console.WriteLine(outputDateString); // Prints 2012/01/01 23:36:17.234
        }
    }
