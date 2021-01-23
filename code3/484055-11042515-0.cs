    class Program
    {
        static void Main(string[] args)
        {
            dynamic obj = new SomeObject();
            obj.someMethodName("hello");
        }
    }
    public class SomeObject
    {
        public void someMethodName(string message)
        {
            Console.WriteLine(message);
        }
    }
