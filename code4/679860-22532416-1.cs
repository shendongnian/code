    public class BaseClass<TSelfRef> where TSelfRef: BaseClass<TSelfRef>
    {
        public static void LogCallerType()
        {
            Console.WriteLine(typeof(TSelfRef).Name);
        }
    }
    public class FooClass : BaseClass<FooClass> { }
    public class BooClass : BaseClass<BooClass> { }
    class Program
    {
        static void Main(string[] args)
        {
            FooClass.LogCallerType();
            BooClass.LogCallerType();
        }
    }
