    class Program
    {
        public static int I = 0;
    
        static Func<int, string> del = num => num.ToString();
    
        static void Main(string[] args)
        {
            I = 10;
            Console.WriteLine("{0}", del(I));
        }
    }
