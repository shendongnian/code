    public static class ListEx
    {
        public static void SetLast<T>(this IList<T> list, T value)
        {
            int lastIdx = list.Count - 1;
            list[lastIdx] = value;
        }
        //and by symmetry
        public static T GetLast<T>(this IList<T> list)
        {
            int lastIdx = list.Count - 1;
            return list[lastIdx];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int> { 1, 2, 3 };
            a.SetLast(4);
            Console.WriteLine(a[2]); //prints 4
        }
    }
