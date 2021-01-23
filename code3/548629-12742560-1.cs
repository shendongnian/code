    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            numbers.AddRange(Enumerable.Range(0, 100000));
            var answer = numbers.BinarySearchWithCount(2);
            Console.WriteLine("item: " + answer.Item1);   // item: 2
            Console.WriteLine("count: " + answer.Item2);  // count: 15
        }
    }
