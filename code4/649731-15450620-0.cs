    class Program
    {
        static void Main(string[] args)
        {
            List<int> listA = new List<int> { 1, 2, 3 };
            List<int> listB = new List<int> { 1, 2, 3 };
            Update(listA);
            UpdateRef(ref listB);
            Console.WriteLine("listA");
            foreach (var val in listA)
                Console.WriteLine(val);
            Console.WriteLine("listB");
            foreach (var val in listB)
                Console.WriteLine(val);
        }
        static void Update(List<int> list)
        {
            list = new List<int>() { 4, 5, 6 };
        }
        static void UpdateRef(ref List<int> list)
        {
            list = new List<int>() { 4, 5, 6 };
        }
    }
