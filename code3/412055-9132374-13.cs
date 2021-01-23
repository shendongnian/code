    public class Program
    {
        private const String one = "1";
        private const String two = "2";
        private const String RESULT = one + two + "34";
        static String MakeIt()
        {
            return "1" + "2" + "3" + "4";
        }   
        static void Main(string[] args)
        {
            string result = "1" + "2" + "34";
            // Prints "True"
            Console.Out.WriteLine(Object.ReferenceEquals(result, MakeIt()));
            // Prints "True" also
            Console.Out.WriteLine(Object.ReferenceEquals(result, RESULT));
            Console.ReadKey();
        }
    }
