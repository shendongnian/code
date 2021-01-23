    class Program
    {
        static void PrintTime(string timeZoneId)
        {
            Console.WriteLine( 
                TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, 
                    timeZoneId).ToShortTimeString() +
                " is the time in " + timeZoneId);
        }
        public static void Main()
        {
            PrintTime("Hawaiian Standard Time");
            PrintTime("Alaskan Standard Time");
            PrintTime("Pacific Standard Time");
            PrintTime("US Mountain Standard Time");
            PrintTime("Central Standard Time");
            PrintTime("US Eastern Standard Time");
        }
    }
