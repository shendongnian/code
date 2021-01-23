        static void Main(string[] args)
        {
            string date = "Wed Jul 25 19:41:36 2012 +0200";
            string format = "ddd MMM dd HH:mm:ss yyyy %K";
            //string format = "ddd MMM dd HH:mm:ss yyyy zzz"; // Also seems to work.
            DateTime dateTime = DateTime.ParseExact(date, format, CultureInfo.InvariantCulture);
            Console.ReadLine();
        }
