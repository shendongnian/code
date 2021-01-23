    .method public hidebysig instance void Test1() cil managed
    {
        .maxstack 4
        .locals init (
            [0] valuetype [mscorlib]System.Decimal[][] originalFormTableau,
            [1] valuetype [mscorlib]System.Decimal[][] standardFormTableau)
        L_0000: ldarg.0 
        L_0001: call instance valuetype [mscorlib]System.Decimal[][] ConsoleApplication2.Class2::CreateOriginalFormTableau()
        L_0006: stloc.0 
        L_0007: ldarg.0 
        L_0008: ldloc.0 
        L_0009: call instance valuetype [mscorlib]System.Decimal[][] ConsoleApplication2.Class2::InsertSlackVariables(valuetype [mscorlib]System.Decimal[][])
        L_000e: stloc.1 
        L_000f: ldarg.0 
        L_0010: ldloc.1 
        L_0011: ldarg.0 
        L_0012: call instance object ConsoleApplication2.Class2::get_normalizationThreshold()
        L_0017: newobj instance void ConsoleApplication2.SimplexEngine::.ctor(valuetype [mscorlib]System.Decimal[][], object)
        L_001c: call instance void ConsoleApplication2.Class2::set_Engine(class ConsoleApplication2.SimplexEngine)
        L_0021: ret 
    }
 
