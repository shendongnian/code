    public static class Extensions
    {
        public static void ForEa<T>(this IList<T> list, Action<T> action)
        {
            for (int i = 0; i < list.Count; i++)
            {
                action(list[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> vals = new List<string>(new string[] { "a", "bc", "de", "f", "gh", "i", "jk" });
            vals.ToList().ForEa<string>(delegate(string value)
            {
                if (value.Length > 1)
                {
                    vals.Remove(value);
                }
            });
            vals.ToList().ForEa<string>(delegate(string value)
            {
                Console.WriteLine(value);
            });
            Console.ReadKey();
        }
    }
