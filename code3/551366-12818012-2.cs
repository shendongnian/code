    public class Class1<T> : IInterface
    where T : Test2
    {
        public T Test { get; private set; }
        Test2 IInterface.Test
        {
            get { ... }
        }
    }
