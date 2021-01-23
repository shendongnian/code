    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            bool check = p.isPowerOfTwo(255);
            Console.WriteLine(check);
            Console.ReadKey();
        }
        public bool isPowerOfTwo(uint x)
        {
            while (((x % 2) == 0) && x > 1)
            {
                x /= 2;
            }
            return (x == 1);
        } 
    }
