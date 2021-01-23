    .method private final hidebysig newslot virtual 
    	instance class [mscorlib]System.Collections.Generic.IEnumerator`1<string> 'System.Collections.Generic.IEnumerable<System.String>.GetEnumerator' () cil managed 
    {
    	.custom instance void [mscorlib]System.Diagnostics.DebuggerHiddenAttribute::.ctor() = (
    		01 00 00 00
    	)
    	.override method instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    	// Method begins at RVA 0x57848
    	// Code size 89 (0x59)
    	.maxstack 6
    	.locals init (
    		[0] bool,
    		[1] class DOT.Core.MiscHelpers/'<ReadLines>d__0',
    		[2] class [mscorlib]System.Collections.Generic.IEnumerator`1<string>
    	)
    
    	IL_0000: call class [mscorlib]System.Threading.Thread [mscorlib]System.Threading.Thread::get_CurrentThread()
    	IL_0005: callvirt instance int32 [mscorlib]System.Threading.Thread::get_ManagedThreadId()
    	IL_000a: ldarg.0
    	IL_000b: ldfld int32 DOT.Core.MiscHelpers/'<ReadLines>d__0'::'<>l__initialThreadId'
    	IL_0010: bne.un IL_0027
