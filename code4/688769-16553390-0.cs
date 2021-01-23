    class Foo
    {
        public string FooProperty { get ; set ; }
        public virtual void FooMethod1() { return ; }
        public virtual void FooMethod2() { return ; }
    }
    class Bar : Foo
    {
        public string FooProperty { get ; set ; }
        public override void FooMethod1() { return ; }
        public void BarMethod1() { return ; }
    }
