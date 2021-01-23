    public class Worker
    {
        public void DoSomething(ICallBack cb)
        {
            ((dynamic)cb).Handle(55);
        }
    }
