    internal class Program
        {
            private static void Main(string[] args)
            {
                dictionary.Add(1, "Test");
                dictionary.Add(2, "TestTest");
                dictionary.Add(3, "TestTestTest");
    
                Console.WriteLine("{0}", ReturnResult(3));
            }
    
            public static Dictionary<int, string> dictionary = new Dictionary<int, string>();
    
            public static string ReturnResult(int index)
            {
                return dictionary.Where(x => x.Key.Equals(index)).Select(res => res.Value).First();
            }
        }
