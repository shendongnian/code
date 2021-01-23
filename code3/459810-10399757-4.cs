    class Base
    {
    public:
        virtual ~Base() {}
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
            Base::Foo();
        }
    };
