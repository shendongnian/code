    public class SomeService
    {
        private readonly IOtherClass _otherClass;
        public SomeService(IOtherClass otherClass)
        {
            _otherClass = otherClass;
        }
        void YourLoopMethod()
        {
           Parallel.Foreach(items, item =>_otherClass.DoWork(item));
        }
     }
