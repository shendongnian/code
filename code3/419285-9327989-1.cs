    using System.Globalization;
    
    class Program
    {
        static void Main(string[] args)
        {
            double d = 1234.12349999;
            char probablyDot = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string[] number = d.ToString().Split(probablyDot);
    
    
            Console.WriteLine(number[0] + probablyDot + number[1].Substring(0, 4));
            //Output: 1234.1234
    
            Console.ReadKey();
        }
    }
