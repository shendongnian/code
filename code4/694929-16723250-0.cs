    class Program
    {
        static void Main(string[] args)
        {
    
            var test = new Test();
            var inner = test.Go();
            var anonObj = new { Name = "one" };
            Console.WriteLine(inner == anonObj.GetType()); // true
        }
    }
    
    public class Test
    {
        public Type Go()
        {
            var anonObj = new { Name = "one" };
            return anonObj.GetType();
        }
    }
