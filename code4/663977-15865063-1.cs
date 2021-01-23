    .method public static void  Main(string[] args) cil managed
    {
      .entrypoint
      .custom instance void [mscorlib]System.STAThreadAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       15 (0xf)
      .maxstack  2
      .locals init 
          (class [mscorlib]System.Collections.Generic.IEnumerable`1<string> V_0)
      IL_0000:  ldarg.0
      IL_0001:  stloc.0
      IL_0002:  ldloc.0
      IL_0003:  ldc.i4.0
      IL_0004:  call       !!0
         [System.Core]System.Linq.Enumerable::ElementAtOrDefault<string>(
            class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
            int32)
      IL_0009:  call       void [mscorlib]System.Console::WriteLine(string)
      IL_000e:  ret
    } // end of method Test::Main
