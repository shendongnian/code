    namespace Managed
    {
        ref class NativeInterface
        {
        public:
           virtual void NativeMethod() abstract;
           virtual void ConcreteMethod() { NativeObj->ConcreteMethod(); }
        public:
           Native::NativeInterface* NativeObj;
        };
    } /// namespace managed
