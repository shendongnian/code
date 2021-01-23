    using System.Globalization;
    
    class Program
    {
        static void Main(string[] args)
        {
            double d = 50234.9489898997952932;
            char probablyDot = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            string[] number = d.ToString().Split(probablyDot);
    
    
            //Console.WriteLine(number[0] + probablyDot + number[1].Remove(4));
            Console.WriteLine(number[0] + probablyDot + (number.Length >1 ? (number[1].Length>4? number[1].Substring(0,4):number[1]): "0000"));
            //Output: 50234.9489
    
            Console.ReadKey();
        }
    }
