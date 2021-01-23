        static void Main(string[] args)
        {
            double smallNumber = -1.01;
            double smallNumberMoreDigits = -1.0001;
            double bigNumber = -100000.001;
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU", false);
            Console.Out.WriteLine(smallNumber.ToString("G"));
            Console.Out.WriteLine(smallNumberMoreDigits.ToString("G"));
            Console.Out.WriteLine(bigNumber.ToString("G"));
            Console.Read();
        }
