    internal class Program
    {
        private static void Main(string[] args)
        {
            Stopwatch sw = Stopwatch.StartNew();
            int[,] array = null;
            for (int i = 0; i < 1000; i++)
            {
                array = ArrayInit();
            }
    
            sw.Stop();
            Console.WriteLine("ArrayInit: {0}", sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            Dictionary<Tuple<sbyte, sbyte>, int> dic = null;
            for (int i = 0; i < 1000; i++)
            {
                dic = DictionaryInit();
            }
    
            sw.Stop();
            Console.WriteLine("DictionaryInit: {0}", sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            int res;
            for (int i = 0; i < 1000000; i++)
            {
                res = ArrayLookup(array);
            }
    
            sw.Stop();
            Console.WriteLine("ArrayLookup: {0}", sw.ElapsedMilliseconds);
    
            sw = Stopwatch.StartNew();
            for (int i = 0; i < 1000000; i++)
            {
                res = DictionaryLookup(dic);
            }
    
            sw.Stop();
            Console.WriteLine("DictionaryLookup: {0}", sw.ElapsedMilliseconds);
    
            Console.Read();
        }
    
        private static int[,] ArrayInit()
        {
            int[,] array = new int[50, 50];
            for (sbyte x = 0; x < 50; x++)
            {
                for (sbyte y = 0; y < 50; y++)
                {
                    array[x, y] = x * y;
                }
            }
    
            return array;
        }
    
        private static int ArrayLookup(int[,] array)
        {
            return array[12, 12];
        }
    
        private static int DictionaryLookup(Dictionary<Tuple<sbyte, sbyte>, int> dic)
        {
            return dic[new Tuple<sbyte, sbyte>(12, 12)];
        }
    
        private static Dictionary<Tuple<sbyte, sbyte>, int> DictionaryInit()
        {
            Dictionary<Tuple<sbyte, sbyte>, int> dic = new Dictionary<Tuple<sbyte, sbyte>, int>();
            for (sbyte x = 0; x < 50; x++)
            {
                for (sbyte y = 0; y < 50; y++)
                {
                    Tuple<sbyte, sbyte> t = new Tuple<sbyte, sbyte>(x, y);
                    dic[t] = x * y;
                }
            }
    
            return dic;
        }
