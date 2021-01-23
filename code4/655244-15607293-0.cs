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
            Point = new P();
            P.Mutate();  // impure function on readonly value type
        }
    }
