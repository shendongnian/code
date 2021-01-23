    public class MyClass
    {
        private MyClass _value = null;
        public MyClass Value {
            get { return _value ?? (_value = new MyClass()); }
        }
    }
