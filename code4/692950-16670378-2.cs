        static void Main(string[] args)
        {
            double smallNumber = -1.01;
            double smallNumberMoreDigits = -1.0001;
            double bigNumber = -100000.001;
            double longNumber = 2.2347894612789;
            
            Thread.CurrentThread.CurrentCulture = new CultureInfo("ru", false);            
            Console.Out.WriteLine(smallNumber.ToString("#,0.####"));
            Console.Out.WriteLine(smallNumberMoreDigits.ToString("#,0.####"));
            Console.Out.WriteLine(bigNumber.ToString("#,0.####"));
            Console.Out.WriteLine(longNumber.ToString("#,0.####"));
            Console.Read();
        }
