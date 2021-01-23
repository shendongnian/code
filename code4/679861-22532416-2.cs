    public class BaseClass<TDerived> where TDerived : BaseClass<TDerived>
    {
        public static void LogCallerType()
        {
            Console.WriteLine(typeof(TDerived).Name);
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
