    class TestClass
    {
        public int MyProperty { get; set; }
        static void SomeStaticMethod()
        {
        }
        public static void SomeOtherStaticMethod()
        {
            SomeStaticMethod(); // You can use the static method inside
        }
        public void InstanceMethod()
        {
            SomeStaticMethod();
        }
    }
