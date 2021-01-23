    class Program
    {
        static void Main(string[] args)
        {
            var list1 = new List<int>() { 1, 2, 3, 4 };
            var list2 = new List<int>() { 1, 2, 3, 4 };
            var list3 = new List<int>() { 2, 3, 3, 4 };
            Console.WriteLine(list1.SequenceEqual(list2)); // True
            Console.WriteLine(list1.SequenceEqual(list3)); // False
            Console.ReadLine();
        }
    }
