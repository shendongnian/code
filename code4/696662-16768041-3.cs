    using System;
    using System.Globalization;
    class Program
    {
        static void Main()
        {
            string dateString = "27/05/2012"; // <-- Valid
            string dtformat = "dd/mm/yyyy";
            DateTime dateTime;
            if (DateTime.TryParseExact(dateString, dtformat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out dateTime))
            {
               Console.WriteLine(dateTime);
            }
        }
    }
