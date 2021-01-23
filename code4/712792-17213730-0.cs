    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Counter.SerialString);
            Counter.Serial++;
            Console.WriteLine(Counter.SerialString);
            Console.ReadKey();
        }
        public class Counter
        {
            public static int Serial;
            public static string SerialString
            {
                get
                {
                    return Serial.ToString("000");
                }
            }
        }
    }
