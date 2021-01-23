    class A
    {
        public int GetFirstInt() { return 1; }
        public virtual int GetSecondInt() { return 2; }
    }
    class B : A
    {
        public int GetFirstInt() { return 11; }
        public override int GetSecondInt() { return 12; }
    }
    A a = new A();
    B b = new B();
    int x = a.GetFirstInt(); // x == 1;
    x = a.GetSecondInt();    // x == 2;
    x = b.GetFirstInt();     // x == 11;
    x = b.GetSecondInt();    // x == 12;
