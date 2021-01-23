     .method public hidebysig static void TryFive() cil managed
    {
        .maxstack 4
        .locals init (
            [0] class Line line,
            [1] class [mscorlib]System.Func`2<int32, valuetype [mscorlib]System.Decimal> func,
            [2] class Line <>g__initLocal9)
        L_0000: newobj instance void Line::.ctor()
        L_0005: stloc.2 
        L_0006: ldloc.2 
        L_0007: ldc.i4.3 
        L_0008: newobj instance void [mscorlib]System.Decimal::.ctor(int32)
        L_000d: stfld valuetype [mscorlib]System.Decimal Line::A
        L_0012: ldloc.2 
        L_0013: ldc.i4.5 
        L_0014: newobj instance void [mscorlib]System.Decimal::.ctor(int32)
        L_0019: stfld valuetype [mscorlib]System.Decimal Line::B
        L_001e: ldloc.2 
        L_001f: stloc.0 
        L_0020: ldloc.0 
        L_0021: ldftn valuetype [mscorlib]System.Decimal SimpleCompute::Compute(class Line, int32)
        L_0027: newobj instance void [mscorlib]System.Func`2<int32, valuetype [mscorlib]System.Decimal>::.ctor(object, native int)
        L_002c: stloc.1 
        L_002d: ldsfld int32[] Test::integers
        L_0032: ldsfld class [mscorlib]System.Func`2<int32, int32> Test::CS$<>9__CachedAnonymousMethodDelegateb
        L_0037: brtrue.s L_004a
        L_0039: ldnull 
        L_003a: ldftn int32 Test::<TryFive>b__a(int32)
        L_0040: newobj instance void [mscorlib]System.Func`2<int32, int32>::.ctor(object, native int)
        L_0045: stsfld class [mscorlib]System.Func`2<int32, int32> Test::CS$<>9__CachedAnonymousMethodDelegateb
        L_004a: ldsfld class [mscorlib]System.Func`2<int32, int32> Test::CS$<>9__CachedAnonymousMethodDelegateb
        L_004f: ldloc.1 
        L_0050: call class [mscorlib]System.Collections.Generic.Dictionary`2<!!1, !!2> [System.Core]System.Linq.Enumerable::ToDictionary<int32, int32, valuetype [mscorlib]System.Decimal>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>, class [mscorlib]System.Func`2<!!0, !!1>, class [mscorlib]System.Func`2<!!0, !!2>)
        L_0055: pop 
        L_0056: ldstr "TryFour complete"
        L_005b: call void [mscorlib]System.Console::WriteLine(string)
        L_0060: ret 
    }
    
