    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    class Test
    {
        static void Main()
        {
            string date = "13/02/07,16:05:13+00";
            DateTime dt = DateTime.ParseExact(date, "yy/MM/dd,HH:mm:ss+00",
                                              CultureInfo.InvariantCulture);
            Console.WriteLine(dt);
        }
    }
