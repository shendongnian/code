    class Program
    {
        static void Main(string[] args)
        {
            var items = new[] { 1, 2, -1, 3, -2, 1, 1, 2, -1, -3 };
            int min = items.First();
            Action<int> minimumSoFar = (int x) => { Console.WriteLine("{0}", Math.Min(min, x)); min = Math.Min(min, x); };
            foreach (var integer in items)
            {
                minimumSoFar.Invoke(integer);
            }
        }
    }
