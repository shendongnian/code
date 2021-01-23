    #pragma managed(push, off)
    #include "oldskool.h"
    #pragma comment(lib, "oldskool.lib")
    #pragma managed(pop)
    using namespace System;
    ref class Wrapper; // You need a predeclaration to use this class in the
                       // constructor of OldSkoolRedirector.
    // Overrides virtual method is native class and passes to wrapper class
    class OldSkoolRedirector : public COldSkool {
    public:
        OldSkoolRedirector(Wrapper ^owner) : m_owner(owner) { }
    protected:
        virtual void sampleVirtualMethod() { // override your pure virtual method
            m_owner->callSampleVirtualMethod(); // body of method needs to be in .cpp file
        }
    private:
        gcroot<Wrapper^> m_owner;
    }
    public ref class Wrapper abstract {
    private:
        COldSkool* pUnmanaged;
    public:
        Wrapper() { pUnmanaged = new OldSkoolRedirector(this); }
        ~Wrapper() { this->!Wrapper(); }
        !Wrapper() {
            if (pUnmanaged) {
                delete pUnmanaged;
                pUnmanaged = 0;
            }
        }
    protected:
        virtual void sampleVirtualMethod() = 0; // Override this one in C#
    internal:
        void callSampleVirtualMethod(){ 
            if (!pUnmanaged) throw gcnew ObjectDisposedException("Wrapper");
            sampleVirtualMethod(); 
        }
    };
