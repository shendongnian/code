    public ref class Wrapper
    {
    public:
        static void WrappedFunction(float% r)
        { pin_ptr<float> p = &r; MyClass::Function(*p); }
    };
