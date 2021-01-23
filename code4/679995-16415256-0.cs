    static void TestNonOverlapped1(int K)
    {
        long total = 1000000000;
        long iter = total / K;
        byte[] tmp = new byte[K];
        byte[] tmp2 = new byte[K];
        for (long i = 0; i < iter; ++i)
        {
            Array.Copy(tmp, tmp2, K);
        }
    }
    static void TestNonOverlapped2(int K)
    {
        long total = 1000000000;
        long iter = total / K;
        byte[] tmp = new byte[K];
        byte[] tmp2 = new byte[K];
        for (long i = 0; i < iter; ++i)
        {
            Buffer.BlockCopy(tmp, 0, tmp2, 0, K);
        }
    }
    static void TestOverlapped1(int K)
    {
        long total = 1000000000;
        long iter = total / K;
        byte[] tmp = new byte[K + 16];
        for (long i = 0; i < iter; ++i)
        {
            Array.Copy(tmp, 0, tmp, 16, K);
        }
    }
    static void TestOverlapped2(int K)
    {
        long total = 1000000000;
        long iter = total / K;
        byte[] tmp = new byte[K + 16];
        for (long i = 0; i < iter; ++i)
        {
            Buffer.BlockCopy(tmp, 0, tmp, 16, K);
        }
    }
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; ++i)
        {
            int N = 16 << i;
            Console.WriteLine("Block size: {0} bytes", N);
            Stopwatch sw = Stopwatch.StartNew();
            {
                sw.Restart();
                TestNonOverlapped1(N);
                Console.WriteLine("Non-overlapped Array.Copy: {0:0.00} ms", sw.Elapsed.TotalMilliseconds);
                GC.Collect(GC.MaxGeneration);
                GC.WaitForFullGCComplete();
            }
            {
                sw.Restart();
                TestNonOverlapped2(N);
                Console.WriteLine("Non-overlapped Buffer.BlockCopy: {0:0.00} ms", sw.Elapsed.TotalMilliseconds);
                GC.Collect(GC.MaxGeneration);
                GC.WaitForFullGCComplete();
            }
            {
                sw.Restart();
                TestOverlapped1(N);
                Console.WriteLine("Overlapped Array.Copy: {0:0.00} ms", sw.Elapsed.TotalMilliseconds);
                GC.Collect(GC.MaxGeneration);
                GC.WaitForFullGCComplete();
            }
            {
                sw.Restart();
                TestOverlapped2(N);
                Console.WriteLine("Overlapped Buffer.BlockCopy: {0:0.00} ms", sw.Elapsed.TotalMilliseconds);
                GC.Collect(GC.MaxGeneration);
                GC.WaitForFullGCComplete();
            }
            Console.WriteLine("-------------------------");
        }
        Console.ReadLine();
    }
