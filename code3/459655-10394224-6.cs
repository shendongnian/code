    class Program
    {
        static void Main(string[] args)
        {
            var myList = Enumerable.Range(0, 100).ToList();
            var myRandoms = myList.Select(v => new { key = v, value = 0 })
                     .ToDictionary(e => e.key, e => e.value);
            for (int i = 0; i < 100; i++)
            {
                var random = myList.RandomOne();
                myRandoms[random]++;
            }
            Console.WriteLine(myRandoms.Values.Max());
            Console.ReadLine();
        }
    }
