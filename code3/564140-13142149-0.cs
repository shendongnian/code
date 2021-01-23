    public class MyClass
    {
        public int MyProperty { get; set; }
        private MyClass(int i)
        {
            MyProperty = i;
        }
        public static implicit operator MyClass(int x)
        {
            return new MyClass(x);
        }
    }
    MyClass myClass = 5;
