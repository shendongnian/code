    interface IA
    {
        void M() { WriteLine("IA.M"); }
    }
    class C : IA { } // OK
    IA i = new C();
    i.M(); // prints "IA.M"`
