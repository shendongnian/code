    class Program
    {
        static void Main(string[] args)
        {
            int to = 50000000;
            OtherStuff os = new OtherStuff();
            
            Console.WriteLine(Profile(() => os.CountTo(to)));
            Console.WriteLine(Profile(() => os.CountTo(to)));
            Console.WriteLine(Profile(() => os.CountTo(to)));
        }
        static long Profile(Action method)
        {
            Stopwatch st = Stopwatch.StartNew();
            method();
            st.Stop();
            return st.ElapsedMilliseconds;
        }
    }
    class OtherStuff
    {
        public void CountTo(int to)
        {
            for (int i = 0; i < to; i++)
            {
                // some work...
                i++;
                i--;
            }
        }
    }
