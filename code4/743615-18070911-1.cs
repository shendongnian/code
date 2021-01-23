    static void Main(string[] args)
    {
        long i;
        int j;
        List<long> primes = new List<long>();
        primes.Add(2);
        long maxJ;
    
        using (System.IO.StreamWriter StreamWriter = System.IO.File.AppendText(@"C:\Users\Marco\Documents\Visual Studio 2012\Projects\Prime Number Generator\Prime Number Generator\bin\Debug\Prime List.txt"))
        {
            for (i = 3; i < 10000000; i += 2)
            {
                //Compute only once, rather that at each iteration
                maxJ = (long)Math.Sqrt(i);
                for (j = 0; j < primes.Count && primes[j] <= maxJ; ++j)
                {
                    if (i % primes[j] == 0)
                    {
                        goto EndOfOuterLoop;
                    }
                }
                Console.WriteLine(i);
                StreamWriter.WriteLine(i);
                primes.Add(i);
                EndOfOuterLoop:
            }
        }
    }
