    struct Point
    {
        public int X;
        public int Y;
        public Point(int x, int y){X = x;Y = y;}
        public void Mutate(){X++;}
        public Point TheoreticallyPure(){return new Point(1, 1);}
        [Pure] public Point MarkedPure(){ return new Point(1, 1);}
    }
    class WithReadonlyField
    {
        public readonly Point P;
        public WithReadonlyField()
        {
            P = new Point();
            P.TheoreticallyPure();  // impure function on readonly value type
            P.MarkedPure(); // return value of pure not used
            P.Mutate();   // impure function on readonly value type - modifies P.
            P = new Point().MarkedPure(); // ok to modify P multiple times.
        }
        public void NormalMethod()
        {
            P.Mutate();   // impure function on readonly value type, no changes to P
        }
    }
