    public interface ICommonInterface
    {
        int MyNumberProperty { get; set; }
        void DoSomething(int i);
    }
    public Class1 : ICommonInterface
    {
        public int MyNumberProperty { get; set; }
        public string AnotherProperty { get; set; }
        public void DoSomething(int i)
        {
            ...
        }
        public string DoSomethingElse()
        {
            ...
        }
    }
    public MyIntClass : ICommonInterface
    {
        public int MyNumberProperty { get; set; }
        public void DoSomething(int i)
        {
            ...
        }
    }
