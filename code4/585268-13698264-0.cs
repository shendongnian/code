    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<int>> dict = new Dictionary<string, List<int>>();
            dict.Add("test", new List<int>() { 8, 5 });
            var dict2 = dict.ToDictionary(y => y.Key, y => y.Value.Sum());
            foreach (var i in dict2)
            {
                Console.WriteLine("Key: {0}, Value: {1}", i.Key, i.Value);
            }
            Console.ReadLine();
        }
    }
