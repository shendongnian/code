    public interface IOtherClassFactory
    {
        IOtherClass Create();
    }
   
    public class SomeService
    {
        private readonly IOtherClassFactory _otherClassFactory;
        public SomeService(IOtherClassFactory otherClassFactory)
        {
            _otherClassFactory = otherClassFactory;
        }
        void YourLoopMethod()
        {
           Parallel.Foreach(items, item =>
                       _otherClassFactory.Create().DoWork(item));
        }
     }
