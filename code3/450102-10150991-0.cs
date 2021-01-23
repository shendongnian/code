    class Program
    {
        const int Million = 1000 * 1000;
        static readonly int NumValues = 32 * Million;
        static void Main(string[] args)
        {
            // Construct a table of integers.
            // These are random powers of two.
            // That is 2^N, where N is in the range 0..31.
            Console.WriteLine("Constructing table");
            int[] values = new int[NumValues];
            Random rnd = new Random();
            for (int i = 0; i < NumValues; ++i)
            {
                int pow = rnd.Next(31);
                values[i] = 1 << pow;
            }
            // Run each one once to make sure it's JITted
            GetLog2_Bithack(values[0]);
            GetLog2_DeBruijn(values[0]);
            GetLog2_Switch(values[0]);
            GetLog2_Naive(values[0]);
            Stopwatch sw = new Stopwatch();
            Console.Write("GetLog2_Naive ... ");
            sw.Restart();
            for (int i = 0; i < NumValues; ++i)
            {
                GetLog2_Naive(values[i]);
            }
            sw.Stop();
            Console.WriteLine("{0:N0} ms", sw.ElapsedMilliseconds);
            Console.Write("GetLog2_Switch ... ");
            sw.Restart();
            for (int i = 0; i < NumValues; ++i)
            {
                GetLog2_Switch(values[i]);
            }
            sw.Stop();
            Console.WriteLine("{0:N0} ms", sw.ElapsedMilliseconds);
            Console.Write("GetLog2_Bithack ... ");
            sw.Restart();
            for (int i = 0; i < NumValues; ++i)
            {
                GetLog2_Bithack(values[i]);
            }
            Console.WriteLine("{0:N0} ms", sw.ElapsedMilliseconds);
            Console.Write("GetLog2_DeBruijn ... ");
            sw.Restart();
            for (int i = 0; i < NumValues; ++i)
            {
                GetLog2_DeBruijn(values[i]);
            }
            sw.Stop();
            Console.WriteLine("{0:N0} ms", sw.ElapsedMilliseconds);
            Console.ReadLine();
        }
        static int GetLog2_Naive(int v)
        {
            int r = 0;
            while ((v = v >> 1) != 0)
            {
                ++r;
            }
            return r;
        }
        static readonly int[] MultiplyDeBruijnBitPosition2 = new int[32]
        {
            0, 1, 28, 2, 29, 14, 24, 3, 30, 22, 20, 15, 25, 17, 4, 8, 
            31, 27, 13, 23, 21, 19, 16, 7, 26, 12, 18, 6, 11, 5, 10, 9
        };
        static int GetLog2_DeBruijn(int v)
        {
            return MultiplyDeBruijnBitPosition2[(uint)(v * 0x077CB531U) >> 27];
        }
        static readonly uint[] b = new uint[] { 0xAAAAAAAA, 0xCCCCCCCC, 0xF0F0F0F0, 0xFF00FF00, 0xFFFF0000};
        static int GetLog2_Bithack(int v)
        {
            int r = (v & b[0]) == 0 ? 0 : 1;
            int x = 1 << 4;
            for (int i = 4; i > 0; i--) // unroll for speed...
            {
                if ((v & b[i]) != 0)
                    r |= x;
                x >>= 1;
            }
            return r;
        }
        static int GetLog2_Switch(int v)
        {
            switch (v)
            {
                case 0x00000001: return 0;
                case 0x00000002: return 1;
                case 0x00000004: return 2;
                case 0x00000008: return 3;
                case 0x00000010: return 4;
                case 0x00000020: return 5;
                case 0x00000040: return 6;
                case 0x00000080: return 7;
                case 0x00000100: return 8;
                case 0x00000200: return 9;
                case 0x00000400: return 10;
                case 0x00000800: return 11;
                case 0x00001000: return 12;
                case 0x00002000: return 13;
                case 0x00004000: return 14;
                case 0x00008000: return 15;
                case 0x00010000: return 16;
                case 0x00020000: return 17;
                case 0x00040000: return 18;
                case 0x00080000: return 19;
                case 0x00100000: return 20;
                case 0x00200000: return 21;
                case 0x00400000: return 22;
                case 0x00800000: return 23;
                case 0x01000000: return 24;
                case 0x02000000: return 25;
                case 0x04000000: return 26;
                case 0x08000000: return 27;
                case 0x10000000: return 28;
                case 0x20000000: return 29;
                case 0x40000000: return 30;
                case int.MinValue: return 31;
                default:
                    return -1;
            }
        }
    }
