        static void Main(string[] args)
        {
            Parallel.For(int.MinValue, int.MaxValue, (x) =>
            {
                float r = x;
                // Is the following ALWAYS true?    
                bool equal = r == x;
                if (!equal) Console.WriteLine("Unequal: " + x);                
            });
            Console.WriteLine("Done");
            Console.ReadKey();
            return;
    }
