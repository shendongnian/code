    public interface IDoSomething
    {
        void DoSomething();
    }
    public sealed class MyClass
    {
        private IDoSomething _doer;
        //We use a Set method rather than a property to prevent other classes from accessing the callback
        //Another common (and generally better) pattern is to pass the instance into the constructor
        public void SetSomethingDoer(IDoSomething doer)
        {
            _doer = doer;
        }
        //Other code can now access _doer to call back the method
    }
