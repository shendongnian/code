    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    namespace Demo
    {
        public static class Program
        {
            private static void Main(string[] args)
            {
                int[] a1 = new int[1000000];
                int[] a2 = new int[1000000];
                for (int i = 0; i < a1.Length-1; ++i)
                {
                    a1[i] = i;
                    a2[i] = i;
                }
                a1[a1.Length-1] = 1;
                a2[a1.Length-1] = 2;
                byte[] b1 = new byte[1000000];
                byte[] b2 = new byte[1000000];
                for (int i = 0; i < b1.Length-1; ++i)
                {
                    b1[i] = (byte)i;
                    b2[i] = (byte)i;
                }
                b1[a1.Length-1] = 1;
                b2[a1.Length-1] = 2;
                Stopwatch sw = Stopwatch.StartNew();
                testWithMemCmp(a1, a2);
                sw.Stop();
                Console.WriteLine("MemCmp with ints took " + sw.Elapsed);
                sw.Restart();
                testWithManagedMemCmp(a1, a2);
                sw.Stop();
                Console.WriteLine("ManagedMemCmp with ints took " + sw.Elapsed);
                sw.Restart();
                testWithMemCmp(b1, b2);
                sw.Stop();
                Console.WriteLine("MemCmp with bytes took " + sw.Elapsed);
                sw.Restart();
                testWithManagedMemCmp(b1, b2);
                sw.Stop();
                Console.WriteLine("ManagedMemCmp with bytes took " + sw.Elapsed);
            }
            private static void testWithMemCmp(int[] a1, int[] a2)
            {
                for (int j = 0; j < COUNT; ++j)
                {
                    MemCmp(a1, a2);
                }
            }
            private static void testWithMemCmp(byte[] a1, byte[] a2)
            {
                for (int j = 0; j < COUNT; ++j)
                {
                    MemCmp(a1, a2);
                }
            }
            private static void testWithManagedMemCmp(int[] a1, int[] a2)
            {
                for (int j = 0; j < COUNT; ++j)
                {
                    ManagedMemCmp(a1, a2);
                }
            }
            private static void testWithManagedMemCmp(byte[] a1, byte[] a2)
            {
                for (int j = 0; j < COUNT; ++j)
                {
                    ManagedMemCmp(a1, a2);
                }
            }
            public static bool ManagedMemCmp(int[] a1, int[] a2)
            {
                if (a1 == null || a2 == null || a1.Length != a2.Length)
                {
                    throw new InvalidOperationException("Arrays are null or different lengths.");
                }
                for (int i = 0; i < a1.Length; ++i)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            public static bool ManagedMemCmp(byte[] a1, byte[] a2)
            {
                if (a1 == null || a2 == null || a1.Length != a2.Length)
                {
                    throw new InvalidOperationException("Arrays are null or different lengths.");
                }
                for (int i = 0; i < a1.Length; ++i)
                {
                    if (a1[i] != a2[i])
                    {
                        return false;
                    }
                }
                return true;
            }
            public static bool MemCmp(byte[] a1, byte[] a2)
            {
                if (a1 == null || a2 == null || a1.Length != a2.Length)
                {
                    throw new InvalidOperationException("Arrays are null or different lengths.");
                }
                return memcmp(a1, a2, new UIntPtr((uint)a1.Length)) == 0;
            }
            public static bool MemCmp(int[] a1, int[] a2)
            {
                if (a1 == null || a2 == null || a1.Length != a2.Length)
                {
                    throw new InvalidOperationException("Arrays are null or different lengths.");
                }
                return memcmp(a1, a2, new UIntPtr((uint)(a1.Length * sizeof(int)))) == 0;
            }
            [DllImport("msvcrt.dll")]
            private static extern int memcmp(byte[] a1, byte[] a2, UIntPtr count);
            [DllImport("msvcrt.dll")]
            private static extern int memcmp(int[] a1, int[] a2, UIntPtr count);
            private const int COUNT = 10000;
        }
    }
