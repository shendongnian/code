    using namespace System;
    using namespace SomeNamespace;
    public ref class Test
    {
    public:
        static void Run()
        {
            IInterface^ foo = gcnew Implementation();
            foo->Print("hello, {0}", "world");
            foo->Print("hello, world");
        }
    };
