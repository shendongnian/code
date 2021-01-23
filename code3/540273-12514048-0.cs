    public static class ComparableEx
    {
        public static bool IsLessThan<T>(this T source, T comparer)  
            where T : IComparable<T>
        {
            return source.CompareTo(comparer) < 0;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int test = 2;
            var resultOne = test.IsLessThan(3); // returns true
            var resultTwo = test.IsLessThan("Hello world"); // doesn't compile
        }        
    }
