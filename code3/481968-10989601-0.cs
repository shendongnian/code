    abstract class MyBaseClass
    {
        public int SharedProperty { get; set; }
        public void SharedMethod()
        {
        }
    }
    class MyClass1 : MyBaseClass
    {
        public void Method1()
        {
        }
    }
    class MyClass2 : MyBaseClass
    {
        public void Method2()
        {
        }
    }
