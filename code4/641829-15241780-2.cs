    public class MyClass
    {
        private AnotherClass _SomeProperty;
        public MyClass()
        {
            _SomeProperty = new AnotherClass();
        }
        public AnotherClass SomeProperty
        {
            get { return _SomeProperty; }
            set
            {
                if(value == null)
                    throw new ArgumentNullException("SomeProperty");
                if(value != _SomeProperty)
                {
                    _SomeProperty = value;
                    // ToDo: Implement RaiseEvent() and declare event.
                    RaiseEvent(MyEvent);
                }       
            }
        }
    }
