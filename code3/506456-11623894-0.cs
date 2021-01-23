    namespace System.Collections.Generic
    {
        public static class DicExt
        {
            public static void AddRange<K, V>(this Dictionary<K, V> dic, IEnumerable<K> keys, V v)
            {
                foreach (var k in keys)
                    dic[k] = v;
            }
        }
    }
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                var list  = new List<string>() { "P", "J", "K", "L", "M" };
                var dic = new Dictionary<string, bool>();
    
                dic.AddRange(list, true);
    
    
                Console.Read();
    
            }
        }
    }
