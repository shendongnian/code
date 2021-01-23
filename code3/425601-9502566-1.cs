    interface IFoo : IComparable<IFoo> 
    { 
        int Value { get; set; } // for example's sake
    }
    
    class SomeFoo : IFoo
    {
        public int Value { get; set; }
        public int CompareTo(IFoo other)
        {
            // implement your custom comparison here...
            return Value.CompareTo(other.Value); // e.g.
        }
    }
