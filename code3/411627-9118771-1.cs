    class Program
    {
        static void Main(string[] args)
        {
            var maybe = 40000000f * 40000000f;
            Console.WriteLine(isNumber(maybe));
            Console.ReadLine();
        }
        public static bool isNumber(object O)
        {
            var s = O.GetType().ToString().ToUpper();
            Console.WriteLine(s); // prints "SINGLE"
            // this is silly
            //return (s.Contains("INT") || s.Contains("DOUBLE") || s.Contains("SINGLE"));
            // better
            return O is int || O is Int64 || O is float || O is double; // etc.
        }
    }
