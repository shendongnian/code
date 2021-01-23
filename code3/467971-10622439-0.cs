    //class in the 3rd party dll
    class NativeClass
    {
    	public:
    	int NativeMethod(int a)
    	{
    		return 1;
    	}	
    };
    
    //wrapper for the NativeClass
    class ref RefClass
    {
    	NativeClass * m_pNative;
    		
    	public:
    	RefClass():m_pNative(NULL)
    	{
    		m_pNative = new NativeClass();
    	}
    
    	int WrapperForNativeMethod(int a)
    	{
    		return m_pNative->NativeMethod(a);
    	}
    
    	~RefClass()
    	{
    		this->!RefClass();
    	}
    
    	//Finalizer
    	!RefClass()
    	{
    		delete m_pNative;
    		m_pNative = NULL;
    	}
    };
