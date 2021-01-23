    using System;
    using System.Globalization;
    using System.Threading;
    
    namespace test {
        public static class Program {
            public static void Main() {
                CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                culture.DateTimeFormat.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";
                culture.DateTimeFormat.LongTimePattern = "";
                Thread.CurrentThread.CurrentCulture = culture;
                Console.WriteLine(DateTime.Now);
            }
        }
    }
