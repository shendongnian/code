    struct Vector
    {
        private readonly int x;  // Immutable types should have readonly fields.
        private readonly int y;
        public int X { get { return x; }} // No setter.
        public int Y { get { return y; }}
    
        // ...
        // some other stuff
    }
