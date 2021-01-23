    .method public hidebysig static void TryTwo() cil managed
    {
        .maxstack 4
        .locals init (
            [0] class Line <>g__initLocal6)
        L_0000: newobj instance void Line::.ctor()
        L_0005: stloc.0 
        L_0006: ldloc.0 
        L_0007: ldc.i4.3 
        L_0008: newobj instance void [mscorlib]System.Decimal::.ctor(int32)
        L_000d: stfld valuetype [mscorlib]System.Decimal Line::A
        L_0012: ldloc.0 
        L_0013: ldc.i4.5 
        L_0014: newobj instance void [mscorlib]System.Decimal::.ctor(int32)
        L_0019: stfld valuetype [mscorlib]System.Decimal Line::B
        L_001e: ldsfld int32[] Test::integers
        L_0023: ldsfld class [mscorlib]System.Func`2<int32, int32> Test::CS$<>9__CachedAnonymousMethodDelegate8
        L_0028: brtrue.s L_003b
        L_002a: ldnull 
        L_002b: ldftn int32 Test::<TryTwo>b__7(int32)
        L_0031: newobj instance void [mscorlib]System.Func`2<int32, int32>::.ctor(object, native int)
        L_0036: stsfld class [mscorlib]System.Func`2<int32, int32> Test::CS$<>9__CachedAnonymousMethodDelegate8
        L_003b: ldsfld class [mscorlib]System.Func`2<int32, int32> Test::CS$<>9__CachedAnonymousMethodDelegate8
        L_0040: call class [mscorlib]System.Collections.Generic.Dictionary`2<!!1, !!2> [System.Core]System.Linq.Enumerable::ToDictionary<int32, int32, valuetype [mscorlib]System.Decimal>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, !!1>, class [mscorlib]System.Func`2<!!0, !!2>)
        L_0045: pop 
        L_0046: ldstr "TryTwo complete"
        L_004b: call void [mscorlib]System.Console::WriteLine(string)
        L_0050: ret 
    }
    
