    class B { protected int x; }
    class D : B 
    { 
        void M() 
        { 
            {
                x = 123; // meaning this.x inherited from B
            }
            if (whatever)
            {
                int x = 10;
