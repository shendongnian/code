    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Format(0.00001));
            Console.WriteLine(Format(1));
            Console.WriteLine(Format(3.2));
            Console.WriteLine(Format(3.22));
            Console.WriteLine(Format(3.256));
            Console.ReadLine();
        }
        static string Format(double dValue)
        {
            if (dValue >= 0.01 && dValue <= 1000.0)
            {
                int temp = (int)Math.Round(dValue * 100);
                if (temp % 100 == 0)
                    return ((int)dValue).ToString();
                else if (temp % 10 == 0)
                    return (string.Format("{0:F1}", dValue));
                else
                    return (string.Format("{0:F2}", dValue));
            }
            else
                return (string.Format("{0:0.##E+00}", dValue));
        }
    }
