    class B
    {
        public virtual void M() { Console.WriteLine("B.M") };
    }
    
    class D1 : Base
    {
        // Hides the base method
        public new void M() { Console.WriteLine("D1.M") };
    }
    
    
    class D2 : Base
    {
        // Overrides the base method
        public override void M() { Console.WriteLine("D2.M") };
    }
    
    ...
    
    D1 d1 = new D1();
    d1.M(); // Prints "D1.M"
    B b1 = d1;
    b1.M(); // Prints "B.M", because D1.M doesn't override B.M
    
    D2 d2 = new D1();
    d2.M(); // Prints "D2.M"
    B b2 = d2;
    b2.M(); // Also prints "D2.M", because D2.M overrides B.M
