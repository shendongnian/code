    .method private final hidebysig newslot virtual 
    	instance class [mscorlib]System.Collections.Generic.IEnumerator`1<string> 'System.Collections.Generic.IEnumerable<System.String>.GetEnumerator' () cil managed 
    {
    	.custom instance void [mscorlib]System.Diagnostics.DebuggerHiddenAttribute::.ctor() = (
    		01 00 00 00
    	)
    	.override method instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    	// Method begins at RVA 0x4830c
    	// Code size 64 (0x40)
    	.maxstack 2
    	.locals init (
    		[0] class DOT.Core.MiscHelpers/'<ReadLines>d__0'
    	)
    
    	IL_0000: call int32 [mscorlib]System.Environment::get_CurrentManagedThreadId()
    	IL_0005: ldarg.0
    	IL_0006: ldfld int32 DOT.Core.MiscHelpers/'<ReadLines>d__0'::'<>l__initialThreadId'
    	IL_000b: bne.un IL_002b
