    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            ValueType v = i;
            
            Console.ReadLine();
        }
    }
    .method private hidebysig static 
    	void Main (
    		string[] args
    	) cil managed 
    {
    	// Method begins at RVA 0x2050
    	// Code size 17 (0x11)
    	.maxstack 1
    	.entrypoint
    	.locals init (
    		[0] int32 i,
    		[1] class [mscorlib]System.ValueType v
    	)
    
    	IL_0000: nop
    	IL_0001: ldc.i4.1
    	IL_0002: stloc.0
    	IL_0003: ldloc.0
    	IL_0004: box [mscorlib]System.Int32
    	IL_0009: stloc.1
    	IL_000a: call string [mscorlib]System.Console::ReadLine()
    	IL_000f: pop
    	IL_0010: ret
    } // end of method Program::Main
