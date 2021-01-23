    class Program
    {
        static void Main(string[] args) {
            var list1 = new EnumerableNode(
              new Node { Data = 1, Next =
              new Node { Data = 2, Next =
              new Node { Data = 3, Next = null }}});
            var list2 = new EnumerableNode(
              new Node { Data = 2, Next =
              new Node { Data = 3, Next =
              new Node { Data = 4, Next = null }}});
            var merged = list1.Concat(list2).Distinct();
            Console.WriteLine(String.Join(",", list1));
            Console.WriteLine(String.Join(",", list2));
            Console.WriteLine(String.Join(",", merged));
            Console.ReadLine();
        }
    }
