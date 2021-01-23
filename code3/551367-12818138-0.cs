    public class Class1<T> : IInterface
        where T : Test2
    {
        private T _test;
        public Test2 Test { get{return _test} }
    }
     
    public class Test2
    { 
    }
    internal interface IInterface 
    {
        Test2 Test { get; }
    }
