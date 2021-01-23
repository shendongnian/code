    // Non-generic
    public class Foo
    {
        public object Value { get; set; }
    }
    // Generic
    public class Foo<T> : Foo
    {
        public new T Value { get; set; }
    }
