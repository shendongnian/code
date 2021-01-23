    using System.Globalization;
    
    class Program
    {
        static void Main(string[] args)
        {
            double d = 1234.12349999;
            char probablyDot = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string[] number = d.ToString().Split(probablyDot);
            if (number.Length > 1 && number[1].Length <= 4)
            {
                Console.WriteLine(number[0] + probablyDot + number[1]);
            }
            else if (number.Length == 1)
            {
                Console.WriteLine(number[0]);
            }
            else
            {
                Console.WriteLine(number[0] + probablyDot + number[1].Remove(4));
            }
            Console.ReadKey();
        }
    }
