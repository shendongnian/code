    // First instruction
	IL_0000: ldsfld class [mscorlib]System.Action CodeMachineTest.Program::'CS$<>9__CachedAnonymousMethodDelegate2'
	IL_0005: brtrue.s IL_0018
	IL_0007: ldnull
	IL_0008: ldftn void CodeMachineTest.Program::'<Main>b__0'()
    // Create a new Action instance for the instruction (Action)(() => DoNothing())
	IL_000e: newobj instance void [mscorlib]System.Action::.ctor(object, native int)
	IL_0013: stsfld class [mscorlib]System.Action CodeMachineTest.Program::'CS$<>9__CachedAnonymousMethodDelegate2'
	IL_0018: ldsfld class [mscorlib]System.Action CodeMachineTest.Program::'CS$<>9__CachedAnonymousMethodDelegate2'
	IL_001d: pop
    // Second instruction
	IL_001e: ldsfld class [mscorlib]System.Action CodeMachineTest.Program::'CS$<>9__CachedAnonymousMethodDelegate3'
	IL_0023: brtrue.s IL_0036
	IL_0025: ldnull
	IL_0026: ldftn void CodeMachineTest.Program::'<Main>b__1'()
	IL_002c: newobj instance void [mscorlib]System.Action::.ctor(object, native int)
	IL_0031: stsfld class [mscorlib]System.Action CodeMachineTest.Program::'CS$<>9__CachedAnonymousMethodDelegate3'
	IL_0036: ldsfld class [mscorlib]System.Action CodeMachineTest.Program::'CS$<>9__CachedAnonymousMethodDelegate3'
	IL_003b: pop
	IL_003c: ret
