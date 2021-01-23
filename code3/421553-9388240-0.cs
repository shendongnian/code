    class Program
    {
        static Dictionary<string, int> _dictionary = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            _dictionary["key1"] = 0;
            _dictionary["key2"] = 0;
            Action<string> updateEntry = (key) =>
                {
                    for (int i = 0; i < 10000000; i++)
                    {
                        _dictionary[key] = _dictionary[key] + 1;
                    }
                };
            var task1 = Task.Factory.StartNew(() =>
                {
                    updateEntry("key1");
                });
            var task2 = Task.Factory.StartNew(() =>
            {
                updateEntry("key2");
            });
            Task.WaitAll(task1, task2);
            Console.WriteLine("Key1 = {0}", _dictionary["key1"]);
            Console.WriteLine("Key2 = {0}", _dictionary["key2"]);
            Console.ReadKey();
        }
    }
