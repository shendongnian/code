    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = new int[10];
            var list1 = new List<int>() { 0, 1, 52 };
            var list2 = new List<string>() { "Mike" };
            func(3, 4, array1, list1, "hello", list2);
        }
        static void func(int x, int y, params object[] arr)
        {
            // Gets all lists and arrays from arr
            IEnumerable<object> listsAndArrays = arr.Where(a => a is IList);
            // Gets all arrays from arr
            IEnumerable<object> arrays = arr.Where(a => a is Array);
            // Gets all lists from arr
            IEnumerable<object> lists = arr.Where(a => a.GetType().IsGenericType && a.GetType().GetGenericTypeDefinition() == typeof(List<>));
        }
    }
