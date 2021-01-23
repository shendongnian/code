    .method private hidebysig static 
    	void Main () cil managed 
    {
    	// Method begins at RVA 0x2050
    	// Code size 14 (0xe)
    	.maxstack 1
    	.entrypoint
    	.locals init (
    		[0] class [mscorlib]System.Collections.Generic.List`1<int32> x,
    		[1] class [mscorlib]System.Collections.Generic.List`1<int32> y
    	)
    
    	IL_0000: nop
    	IL_0001: newobj instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    	IL_0006: stloc.0
    	IL_0007: newobj instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor()
    	IL_000c: stloc.1
    	IL_000d: ret
    } // end of method Program::Main
