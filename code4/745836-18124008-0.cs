    class Program
    {
        static void Main(string[] args)
        {
            string t1 = "06:37:30:210:111";
            string t2 = "06:38:32:310:222";
            var tp1 = TimeSpan.ParseExact(
                t1.Remove(t1.LastIndexOf(":")),
                @"hh\:mm\:ss\:FFFFFF",
                CultureInfo.InvariantCulture);
            var tp2 = TimeSpan.ParseExact(
                t2.Remove(t2.LastIndexOf(":")),
                @"hh\:mm\:ss\:FFFFFF",
                CultureInfo.InvariantCulture);
            Console.WriteLine(tp2 - tp1);
        }
    }
