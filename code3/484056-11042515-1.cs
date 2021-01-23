    class Program
    {
        static void Main(string[] args)
        {
            dynamic obj = new SomeObject();
            var meth = obj.GetType().GetMethod("someMethodName");
            meth.Invoke(obj, new object[1]{"hello"});
        }
    }
    public class SomeObject
    {
        public void someMethodName(string message)
        {
            Console.WriteLine(message);
        }
    }
