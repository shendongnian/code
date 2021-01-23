    struct Point
    {
        int X;
        int Y;
        bool Mutate() { X++; Y++; }
    }
    
    class Foo
    {
        public readonly Point P;
        Foo() 
        { 
            P = new Point();
            P.Mutate();  // impure function on readonly value type
        }
    }
