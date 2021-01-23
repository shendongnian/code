    using System;
    using System.Globalization;
    class Test
    {
        static void Main()
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(1391, 4, 7, pc);
            Console.WriteLine(dt.ToString(CultureInfo.InvariantCulture));
        }
    }
