    using System;
    using System.Globalization;
    class Test
    {
        static void Main()
        {
            DateTime dt = new DateTime(1391, 4, 7);
            Console.WriteLine(dt.ToString(CultureInfo.Invariantculture));
        }
    }
