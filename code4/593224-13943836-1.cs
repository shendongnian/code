    class A
    {
        public int SomeProperty { get; set; }
    }
    class B
    {
        public int SomeMethod(int value)
        {
            return value;
        }
    }
    dynamic d = new A();
    d.Value = 1;
    d = new B();
    d.SomeMethod(2);
 
