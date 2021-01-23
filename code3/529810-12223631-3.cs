    class Program
    {
        [DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
        static extern int memcmp(byte[] b1, byte[] b2, long count);
        static bool AreEqualNative(byte[] a, byte[] b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Length != b.Length)
                return false;
            return memcmp(a, b, a.Length) == 0;
        }
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
        static bool AreEqualSafeParallel(byte[] a1, byte[] a2, int start, int length)
        {
            for (int i = start; i < length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }
            return true;
        }
        static bool AreEqualSafeParallel(byte[] a, byte[] b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Length != b.Length)
                return false;
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            int quar = a.Length / 4;
            Parallel.Invoke(
                () => b1 = AreEqualSafeParallel(a, b, 0, quar),
                () => b2 = AreEqualSafeParallel(a, b, quar, quar),
                () => b3 = AreEqualSafeParallel(a, b, quar * 2, quar),
                () => b4 = AreEqualSafeParallel(a, b, quar * 3, a.Length)
            );
            return b1 && b2 && b3 && b4;
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
        static unsafe bool AreEqualUnsafeParallel(byte[] a, byte[] b, int start, int length)
        {
            int len = length / 8;
            if (len > 0)
            {
                fixed (byte* ap = &a[0])
                fixed (byte* bp = &b[0])
                {
                    long* apl = (long*)ap;
                    long* bpl = (long*)bp;
                    for (int i = start; i < len; i++)
                    {
                        if (apl[i] != bpl[i])
                            return false;
                    }
                }
            }
            int rem = length % 8;
            if (rem > 0)
            {
                for (int i = length - rem; i < length; i++)
                {
                    if (a[i] != b[i])
                        return false;
                }
            }
            return true;
        }
        static unsafe bool AreEqualUnsafeParallel(byte[] a, byte[] b)
        {
            if (a == b)
                return true;
            if (a == null || b == null)
                return false;
            if (a.Length != b.Length)
                return false;
            bool b1 = false;
            bool b2 = false;
            bool b3 = false;
            bool b4 = false;
            int quar = a.Length / 4;
            Parallel.Invoke(
                () => b1 = AreEqualUnsafeParallel(a, b, 0, quar),
                () => b2 = AreEqualUnsafeParallel(a, b, quar, quar),
                () => b3 = AreEqualUnsafeParallel(a, b, quar * 2, quar),
                () => b4 = AreEqualUnsafeParallel(a, b, quar * 3, a.Length)
            );
            return b1 && b2 && b3 && b4;
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
            Console.WriteLine(name + " Random took:");
            Console.WriteLine("\t" + sw1.Elapsed);
            var c = new byte[length];
            var d = new byte[length];
            var sw2 = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                func(c, d);
            }
            sw2.Stop();
            Console.WriteLine(name + " Non-Random took:");
            Console.WriteLine("\t" + sw2.Elapsed);
        }
        static void Test(bool shouldBeEqual, byte[] a, byte[] b)
        {
            if (shouldBeEqual != AreEqualSafe(a, b))
                throw new Exception();
            if (shouldBeEqual != AreEqualSafeParallel(a, b))
                throw new Exception();
            if (shouldBeEqual != AreEqualUnsafe(a, b))
                throw new Exception();
            if (shouldBeEqual != AreEqualUnsafeParallel(a, b))
                throw new Exception();
            if (shouldBeEqual != AreEqualNative(a, b))
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
            var length = 1000000;
            var iterations = 10000;
            Console.WriteLine("Length:");
            Console.WriteLine("\t" + length.ToString("N"));
            Console.WriteLine("Iterations:");
            Console.WriteLine("\t" + iterations.ToString("N"));
            SpeedTest("Safe", length, iterations, AreEqualSafe);
            SpeedTest("SafeParallel", length, iterations, AreEqualSafeParallel);
            SpeedTest("Unsafe", length, iterations, AreEqualUnsafe);
            SpeedTest("UnsafeParallel", length, iterations, AreEqualUnsafeParallel);
            SpeedTest("Native", length, iterations, AreEqualNative);
            Console.ReadLine();
        }
    }
