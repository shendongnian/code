    #pragma once
    
    using namespace System;
    using namespace System::Runtime::InteropServices;
    
    typedef void (*FunctionPtr2)(int); 
    extern "C" __declspec(dllimport)void Caller();
    extern "C" __declspec(dllimport)void RegisterFunction(FunctionPtr2 func_ptr); 
    
    namespace MyDllCLR {
        
        void MyFunc(int i);
    
    	public ref class Class
    	{        
        public:
            delegate void FunctionDelegate(int i);
            static FunctionDelegate^ fun;
    
            static void Caller1()
            {
                Caller();
            }
    
            static void RegisterFunction1(FunctionDelegate^ f)
            {
                fun = f; // Wrapper MyFunc call this delegate
    
                // this occurs runtime error and I don't know why.
                // So I wrote Warpper MyFunc() method. I usually do like this.
                //IntPtr p = Marshal::GetFunctionPointerForDelegate(fun);
                //RegisterFunction((FunctionPtr2)(void*)p);
    
                // Register Function Wrapper instead of user delegate.
                RegisterFunction(MyFunc);
            }
    	};    
    }
