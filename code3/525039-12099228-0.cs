    public class MySuperAwesomeProperty<T>
    {
        private T backingField;
        private Func<T, T> getter;
        private Func<T, T> setter;
        public MySuperAwesomeProperty(Func<T, T> getter, Func<T, T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }
    
        public T Value
        {
            get
            {
                return getter(backingField);
            }
            set
            {
                backingField = setter(value);
            }
        }
    }
    
    public class Foo
    {
        public MySuperAwesomeProperty<int> Bar { get; private set; }
    
    
        public Foo()
        {
            Bar = new MySuperAwesomeProperty<int>(
                value => value, value => { doStuff(); return value; });
    
            Bar.Value = 5;
    
            Console.WriteLine(Bar.Value);
        }
    
        private void doStuff()
        {
            throw new NotImplementedException();
        }
    }
