    .method public hidebysig instance void Test2() cil managed
    {
        .maxstack 8
        L_0000: ldarg.0 
        L_0001: ldarg.0 
        L_0002: ldarg.0 
        L_0003: call instance valuetype [mscorlib]System.Decimal[][] ConsoleApplication2.Class2::CreateOriginalFormTableau()
        L_0008: call instance valuetype [mscorlib]System.Decimal[][] ConsoleApplication2.Class2::InsertSlackVariables(valuetype [mscorlib]System.Decimal[][])
        L_000d: ldarg.0 
        L_000e: call instance object ConsoleApplication2.Class2::get_normalizationThreshold()
        L_0013: newobj instance void ConsoleApplication2.SimplexEngine::.ctor(valuetype [mscorlib]System.Decimal[][], object)
        L_0018: call instance void ConsoleApplication2.Class2::set_Engine(class ConsoleApplication2.SimplexEngine)
        L_001d: ret 
    }
