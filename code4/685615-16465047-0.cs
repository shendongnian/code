    void Main()
    {
        Worker foo = new Worker();
        ICallBack boo = new MessageHandler();
        
        foo.DoSomething(boo);
    }
    
    public interface ICallBack
    {
        void Handle<T>(T arg);
    }
    
    public class MessageHandler : ICallBack
    {
        void ICallBack.Handle<T>(T arg)
        {
            string name = typeof(T).Name;
            Console.WriteLine(name);
        }
    }
    
    public class Worker
    {
        public void DoSomething(ICallBack cb)
        {
            ((dynamic)cb).Handle(55);
        }
    }
