    class Base
    {
    public:
        virtual void Foo() = 0; //setting a virtual function to 0 makes it pure virtual.     This is abstract.
    }
    class C : Base
    {
    public:
        void Foo()
        {
            Base::Foo(); //I don't think this line will work...You're calling an abstract method.
        }
    }
