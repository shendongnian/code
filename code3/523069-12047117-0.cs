    public ref class TestClass
    {
        ~TestClass() { Debug::WriteLine("Disposed"); }
        !TestClass() { Debug::WriteLine("Finalized"); }
    };
