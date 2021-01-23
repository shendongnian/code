    interface I
    {
        void M();
    }
    class A : I
    {
        void I.M()
        {
            
        }
    }
    class B : A
    {
        void I.M() // Compilation error
        {
            
        }
    }
