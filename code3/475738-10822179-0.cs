    public class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(Test.TestMethod(new[] {new {txt = "test"}}));
            Console.ReadLine();
        }
    }
    public class Test
    {
        public static string TestMethod(IEnumerable<dynamic> obj)
        {
            return obj.Select(o => o.txt).FirstOrDefault();
        }
    }
