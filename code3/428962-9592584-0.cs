    using System;
    using System.Globalization;
    
    class Test
    {
        static void Main() 
        {
            string text = "09/Feb/2012:00:38:48";
            DateTime value;
            if (DateTime.TryParseExact(text, "dd/MMM/yyyy:HH:mm:ss",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.None,
                                       out value))
            {
                Console.WriteLine("Success! {0}", value);
            }
            else
            {
                Console.WriteLine("Failed");
            }
        }
    }
