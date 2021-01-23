    abstract class MyBase
    {
        protected MyBase(string foo) { }
    }
    class Child : MyBase
    {
        public Child(string foo)
            : base(foo) 
        { }
    }
