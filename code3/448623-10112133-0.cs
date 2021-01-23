    //C++ DLL (__stdcall calling convention)
    extern "C" __declspec(dllexport) void Foo(double *result) {
        *result = 1.2;
    }
    
    //C#    
    class Program
    {
    	[DllImport( "Snadbox.dll", CallingConvention=CallingConvention.StdCall )]
    	static extern void Foo( ref double output );
    
    	static void Main( string[] args )
    	{
    		double d = 0;			
    		Foo( ref d );
    
    		Console.WriteLine( d ); // prints "1.2"			
    	}
    }
