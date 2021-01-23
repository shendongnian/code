    interface ISession
    {
        // session members
    }
    class FakeSession : ISession
    {
        public void Query()
        {
            Console.WriteLine("fake implementation");
        }
    }
    static class ISessionExtensions
    {
        public static void Query(this ISession test)
        {
            Console.WriteLine("real implementation");
        }
    }
    static void Stub1(ISession test)
    {
        test.Query(); // calls the real method
    }
    static void Stub2<TTest>(TTest test) where TTest : FakeSession
    {
        test.Query(); // calls the fake method
    }
