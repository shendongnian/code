    public class Foo<out T> // Imagine if this were valid
    {
        private T value;
        
        public T Value { get { return value; } }
        public Foo(T value)
        {
            this.value = value;
        }
    }
