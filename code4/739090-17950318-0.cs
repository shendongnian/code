    class Program
    {
        public unsafe static int Search()
        {
            int i = 0;
            float* f = (float*)&i;
            while (*f >= 0 && *f <= 1)
            {
                f = (float*)&i;
                i++;
            }
            return i;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(Search());
            Console.ReadLine();
        }
    }
