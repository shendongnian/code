    class Foo : IComparable<Foo>
    {
        private static readonly Foo Min = new Foo(Int32.MinValue);
    
        private readonly int value;
    
        public Foo(int value)
        {
            this.value = value;
        }
    
        public int CompareTo(Foo other)
        {
            return this.value.CompareTo((other ?? Min).value);
        }
    
        public static bool operator <(Foo a, Foo b)
        {
            return (a ?? Min).CompareTo(b) < 0;
        }
    
        public static bool operator >(Foo a, Foo b)
        {
            return (a ?? Min).CompareTo(b) > 0;
        }
    }
