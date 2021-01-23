    class Program
    {
        static void Main(string[] args)
        {
            BitArray bitArray = new BitArray(10000000);
            bool[] boolArray = new bool[10000000];
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();
            for (int i = 0; i < 10000000; i++)
            {
                bitArray[i] = GetMod2(i);
            }
            Console.WriteLine(sw1.ElapsedMilliseconds);
            sw1.Restart();
            var list = new List<bool>();
            for (int i = 0; i < 10000000; i++)
                list.Add(GetMod2(i));
            var boolArray2 = list.ToArray();
            Console.WriteLine(sw1.ElapsedMilliseconds);
            sw1.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                bool nextVal = GetMod2(i);
                if (nextVal)
                    bitArray[i] = true;
            }
            Console.WriteLine(sw1.ElapsedMilliseconds);
            sw1.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                boolArray[i] = GetMod2(i);
            }
            Console.WriteLine(sw1.ElapsedMilliseconds);
            sw1.Restart();
            for (int i = 0; i < 10000000; i++)
            {
                boolArray[i] = GetRand(i);
            }
            Console.WriteLine(sw1.ElapsedMilliseconds);
            Console.ReadLine();
        }
        static bool GetMod2(int i)
        {
            return (i % 2) == 1;
        }
        static bool GetRand(int i)
        {
            return new Random().Next(2) == 1;
        }
    }
