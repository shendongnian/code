    using System.Globalization;
    class Program {
        static void Main(string[] args) {
            double d = 12.345;
            string s = string.Format(CultureInfo.InvariantCulture, "{0:0.00}%", d);
        }
    }
