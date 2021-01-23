    namespace TimeProcessing
    {
        using System;
        using System.Diagnostics;
        using System.Globalization;
        class Program
        {
            static void Main(string[] args)
            {
                double timeStamp = 1000000000; // here you read real UNIX timespamp
                // get UTC time
                DateTime utc = ConvertFromUnixTimestamp(timeStamp);
                Console.WriteLine("UTC time is: {0}", utc.ToString("o", CultureInfo.CurrentCulture));
                // get local time
                DateTime local = TimeZone.CurrentTimeZone.ToLocalTime(utc);
                Console.WriteLine("Local time is: {0}", local.ToString("o", CultureInfo.CurrentCulture));
                if(Debugger.IsAttached)
                {
                    Console.WriteLine("Press any key to exit..");
                    Console.ReadKey();
                }
            }
            // here you implement your timestamp processing algorithm
            public static DateTime ConvertFromUnixTimestamp(double timestamp)
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                return origin.AddSeconds(timestamp);
            }
        }
    }
