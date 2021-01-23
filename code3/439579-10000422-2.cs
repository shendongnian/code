    class MyBase
    {
        protected MyBase(MyType type) { this.type = type; }
        MyType type;
        public MyType Type { get { return type; } }
    }
    class MyChild1 : MyBase
    {
        public MyChild1() : base(MyType.Child1) { }
    }
