    class MyGenericClass<T>
    {
        public static T MyProperty { get; set; }
    }
    class MyIntClass
    {
        public static int MyProperty { get; set; }
    }
    class UseThem
    {
        public void test()
        {
            // both are JIT'ed to be exactly the same machine code
            var foo = MyGenericClass<int>.MyProperty;
            var bar = MyOtherClass.MyProperty;
        }
    }
