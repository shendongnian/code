    void Main()
    {
        B b = new B();
        b.CallA().Dump();
    }
    class A
    {
        public string CallA(string someVar)
        {
           return string.Format("{0} says Hello", someVar);
        }
    }
    class B : A
    {
        public string CallA(string someVar = null)
        {
           return base.CallA(someVar);
        }
    }
