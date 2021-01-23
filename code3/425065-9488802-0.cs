    using System;
    using System.Globalization;
    using System.Threading;
    
    class Test
    {
        static void Main()
        {
            CultureInfo ci = new CultureInfo("ar-SA");
            Thread.CurrentThread.CurrentCulture = ci;
            string formattedDate = DateTime.Today.ToString("dd/MM/yyyy");
            Console.WriteLine(formattedDate);
        }
    }
