        static void Main(string[] args)
        {
            double smallNumber = -1.0001;
            double largeNumber = -1000000000.0001;
            NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat; ;
            nfi.NumberGroupSeparator = " ";
            nfi.NumberDecimalSeparator = ",";
            nfi.NumberDecimalDigits = 4;
            Console.Out.WriteLine(smallNumber.ToString("N", nfi));
            Console.Out.WriteLine(largeNumber.ToString("N", nfi));
            Console.Read();
        }
