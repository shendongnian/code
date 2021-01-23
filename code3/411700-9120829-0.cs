    class A
    {
    public:
       virtual int f(char);
    };
    
    class B : public A
    {
    public:
        virtual int f(); //hides A::f
    };
    
    class C : public A
    {
    public:
        virtual int f(char); //overrides A::f
    };
