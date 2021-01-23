    void Handle(C c)
    {
       dynamic cc = c;  
       HandleSpecific(cc);   
    }
    void HandleSpecific(A a)
    {
    //Specific behavior A
    }
    void HandleSpecific(B b)
    {
    //Specific behavior B
    }
