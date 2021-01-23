    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    namespace Test
    {
        [StructLayout(LayoutKind.Explicit, Pack = 1, Size = 8)]
        unsafe struct BUF
        {
        }
        static class Program
        {
            static void Main()
            {
                BUF x, y, z;
                unsafe
                {
                    Do1(&x, &y);
                    Do2(&y, &z);
                }
                // Readline here to allow attaching debugger and dumping jitted code
                Console.ReadLine();
            }
            // Disable inlining to permit easier identification of the code
            [MethodImpl(MethodImplOptions.NoInlining)]
            unsafe static void Do1(BUF* src, BUF* dst)
            {
                *((BUF*)dst) = *((BUF*)src);
            }
            // Disable inlining to permit easier identification of the code
            [MethodImpl(MethodImplOptions.NoInlining)]
            unsafe static void Do2(BUF* src, BUF* dst)
            {
                *((long*)dst) = *((long*)src);
            }
        }
    }
