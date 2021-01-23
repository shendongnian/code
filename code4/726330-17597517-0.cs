    internal class Program
    {
        private static void Main(string[] args)
        {
            int y = 1;
            int z = y.Extended(n => "hi!");
        }
    }
    public static class X
    {
        public static T Extended<T, L>(this T o, Func<T, L> func)
        {
            return default(T);
        }
    }
