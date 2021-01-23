    class Program
    {
        static void Main(string[] args)
        {
            string something = "Apple";
            int test = 5;
            var list = something.GetList();
            var listint = test.GetList();
            Console.WriteLine(list.GetType());
        }
    }
    static class Extension
    {
        public static List<T> GetList<T>(this T value)
        {
            return new[] { value }.ToList();
        }
    }
