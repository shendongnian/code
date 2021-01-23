    #include "GetActiveNames.h" // replace with the actual GetActiveNames's header
    using namespace System;
    using namespace System::Runtime::InteropServices;
    
    public ref class ActiveNames
    {
    private:
        array<String^>^ m_activeNames;
    
    public:
        property array<String^>^ ActiveNames
        {
            array<String^>^ get()
            {
                return m_activeNames;
            }
    
            void set(array<String^>^ names)
            {
                m_activeNames = names;
            }
        }
        void GetActiveNames()
        {
            signed char** names = new signed char*[100];
            try
            {
                ::GetActiveNames(reinterpret_cast<char**>(names));
    
                ActiveNames = gcnew array<String^>(100);
    
                for (int i = 0; i < 100; ++i)
                    ActiveNames[i] = gcnew String(names[i]);
            catch (...)
            {
                delete[] names;
                throw;
            }
    
            delete[] names;
        }
    };
