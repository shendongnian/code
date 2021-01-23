    public struct Foo
    {
        private readonly int value;
        public Foo(int value)
        {
            this.value = value;
        }
        public int ValuePlusOne { get { return value + 1; } }
    }
    ...
    Foo foo = new Foo(); // Look ma, no value! (Defaults to 0)
    int x = foo.ValuePlusOne; // x is now 1
