    class Base
    {
    public:
        virtual void Foo()
        {
            // do stuff
        }
    };
    
    class C : public Base
    {
    public:
        void Foo()
        {
            base::Foo();
        }
    };
