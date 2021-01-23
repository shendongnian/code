    namespace ClassLibrary1 
    {
    	using namespace System;
    	using namespace System::Dynamic;
    
    	public ref class Class1 : public DynamicObject
    	{
    	public:
    		[System::Runtime::CompilerServices::Dynamic]
    		static property Object^ Global
    		{
    		public:
    			Object^ get()
    			{
    				return gcnew Class1();
    			}
    		}
    
    	public:
    		String^ Test()
    		{
    			return "Test";
    		}
    	};
    }
