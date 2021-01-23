    class Program
    {
        static void Main(string[] args)
        {
            var result = Add<int, long, float>(1, 2);
            Console.WriteLine(result); // 3
            Console.WriteLine(result.GetType().FullName); // System.Single
            Console.Read();
        }
        static T3 Add<T1, T2, T3>(T1 left, T2 right)
        {
            dynamic d1 = left;
            dynamic d2 = right;
            return (T3)(d1 + d2);
        }
    }
