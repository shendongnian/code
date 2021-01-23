    class Program
    {
        static bool AreEqualSafe(byte[] a1, byte[] a2)
        {
            if (a1 == a2)
                return true;
            if (a1 == null || a2 == null)
                return false;
            if (a1.Length != a2.Length)
                return false;
            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }
            return true;
        }
        static unsafe bool AreEqualUnsafe(byte[] a, byte[] b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Length != b.Length)
                return false;
            int len = a.Length / 8;
            if (len > 0)
            {
                fixed (byte* ap = &a[0])
                fixed (byte* bp = &b[0])
                {
                    long* apl = (long*)ap;
                    long* bpl = (long*)bp;
                    for (int i = 0; i < len; i++)
                    {
                        if (apl[i] != bpl[i])
                            return false;
                    }
                }
            }
            int rem = a.Length % 8;
            if (rem > 0)
            {
                for (int i = a.Length - rem; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                        return false;
                }
            }
            return true;
        }
        static readonly Random _rnd = new Random();
        static void SpeedTest(string name, int length, int iterations, Func<byte[], byte[], bool> func)
        {
            var a = new byte[length];
            var b = new byte[length];
            _rnd.NextBytes(a);
            _rnd.NextBytes(b);
            var sw1 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                func(a, b);
            }
            sw1.Stop();
            Console.WriteLine(name + " Random took: " + sw1.Elapsed);
            var c = new byte[length];
            var d = new byte[length];
            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                func(c, d);
            }
            sw2.Stop();
            Console.WriteLine(name + " Non-Random took: " + sw2.Elapsed);
        }
        static void Test(bool shouldBeEqual, byte[] a, byte[] b)
        {
            if (shouldBeEqual != AreEqualSafe(a, b))
                throw new Exception();
            if (shouldBeEqual != AreEqualUnsafe(a, b))
                throw new Exception();
        }
        static void VerifyCorrectness()
        {
            Test(true,
            new byte[] { 1, 2, 3, 4, 5, 6, 7 },
            new byte[] { 1, 2, 3, 4, 5, 6, 7 });
            Test(true,
            new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 },
            new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            Test(false,
            new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
            new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 12 });
        }
        
        static void Main(string[] args)
        {
            VerifyCorrectness();
            var length = 100000;
            var iterations = 10000;
            Console.WriteLine("Length: " + length);
            Console.WriteLine("Iterations: " + iterations);
            SpeedTest("Warmup", length, iterations, (a, b) => true);
            SpeedTest("Safe", length, iterations, AreEqualSafe);
            SpeedTest("Unsafe", length, iterations, AreEqualUnsafe);
            Console.ReadLine();
        }
    }
