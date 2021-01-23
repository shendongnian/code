    class A
    {
    public:
        void DoSomething()
        {
            ....
        }
    };
    class B
    {
    public:
        A MakeA()
        {
             return A();
        }
    };
    B().MakeA().DoSomething();
