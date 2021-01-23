    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Compare<double>("123.1", 125.3, (a, b) => a > b));
            Console.WriteLine(Compare<DateTime>("19/03/2013", DateTime.Now, (a, b) => a == b));
        }
        private static bool Compare<T>(string valueAsString, T valueToComapare, Func<T,T,bool> check)
        {
            var asObject = (T)Convert.ChangeType(valueAsString, typeof(T));
            if (asObject != null)
            {
                return check(asObject, valueToComapare);
            }
            return false;
        }
    }
