    namespace Native {
    class NativeInterface
    {
    public:
        /// Yes, no implementation here, in the "native world"
        virtual void NativeMethod() = 0;
        /// Some other method(s) you'd like to call
        virtual void ConcreteMethod() { cout << "Hello" << endl; }
    };
    } // namespace Native
