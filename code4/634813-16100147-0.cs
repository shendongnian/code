        static void Main(string[] args)
        {
            string s = "201.99999999999997";
            // print s as string
            Console.WriteLine(s);
            // print s as double
            Console.WriteLine(double.Parse(s, System.Globalization.CultureInfo.InvariantCulture));
            // print s as double, converted back to string
            Console.WriteLine(double.Parse(s, System.Globalization.CultureInfo.InvariantCulture).ToString());
            Console.ReadKey();
            // output is:
            // 201.99999999999997
            // 202
            // 202
        }
