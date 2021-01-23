    public ref class Wrapper
    {
    public:
        static void WrappedFunction(float% r)
        { float copy = r; MyClass::Function(copy); r = copy; }
    };
