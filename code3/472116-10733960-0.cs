    public interface IMyServiceContainer 
    {
        IMyService1 MyService1 { get; }
        IMyService2 MyService2 { get; }
        IMyService3 MyService3 { get; }
    }
    public class MyServiceContainer 
    {
        public IMyService1 MyService1 { get; private set; }
        public IMyService2 MyService2 { get; private set; }
        public IMyService3 MyService3 { get; private set; }
        public MyServiceContainer(IMyService1 myService1, IMyService2 myService2, IMyService3 myService3)
        {
            MyService1 = myService1;
            MyService2 = myService2;
            MyService3 = myService3;
        }
    }
