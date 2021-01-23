    .method private hidebysig static void  Main() cil managed
    {
      .entrypoint
      // Code size       146 (0x92)
      .maxstack  2
      .locals init ([0] class [mscorlib]System.Collections.Generic.List`1<int32> list,
               [1] int32 total,
               [2] int32 i,
               [3] class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> enumerable,
               [4] valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32> CS$5$0000,
               [5] bool CS$4$0001,
               [6] class [mscorlib]System.Collections.Generic.IEnumerator`1<int32> CS$5$0002)
      IL_0000:  nop
      IL_0001:  ldc.i4.1
      IL_0002:  ldc.i4     0x2710
      IL_0007:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [System.Core]System.Linq.Enumerable::Range(int32,
                                                                                                                                      int32)
      IL_000c:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<int32>::.ctor(class [mscorlib]System.Collections.Generic.IEnumerable`1<!0>)
      IL_0011:  stloc.0
      IL_0012:  ldc.i4.0
      IL_0013:  stloc.1
      IL_0014:  nop
      IL_0015:  ldloc.0
      IL_0016:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<int32>::GetEnumerator()
      IL_001b:  stloc.s    CS$5$0000
      .try
      {
        IL_001d:  br.s       IL_002d
        IL_001f:  ldloca.s   CS$5$0000
        IL_0021:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::get_Current()
        IL_0026:  stloc.2
        IL_0027:  nop
        IL_0028:  ldloc.1
        IL_0029:  ldloc.2
        IL_002a:  add
        IL_002b:  stloc.1
        IL_002c:  nop
        IL_002d:  ldloca.s   CS$5$0000
        IL_002f:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>::MoveNext()
        IL_0034:  stloc.s    CS$4$0001
        IL_0036:  ldloc.s    CS$4$0001
        IL_0038:  brtrue.s   IL_001f
        IL_003a:  leave.s    IL_004b
      }  // end .try
      finally
      {
        IL_003c:  ldloca.s   CS$5$0000
        IL_003e:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<int32>
        IL_0044:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0049:  nop
        IL_004a:  endfinally
      }  // end handler
      IL_004b:  nop
      IL_004c:  ldloc.0
      IL_004d:  stloc.3
      IL_004e:  nop
      IL_004f:  ldloc.3
      IL_0050:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<int32>::GetEnumerator()
      IL_0055:  stloc.s    CS$5$0002
      .try
      {
        IL_0057:  br.s       IL_0067
        IL_0059:  ldloc.s    CS$5$0002
        IL_005b:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<int32>::get_Current()
        IL_0060:  stloc.2
        IL_0061:  nop
        IL_0062:  ldloc.1
        IL_0063:  ldloc.2
        IL_0064:  add
        IL_0065:  stloc.1
        IL_0066:  nop
        IL_0067:  ldloc.s    CS$5$0002
        IL_0069:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_006e:  stloc.s    CS$4$0001
        IL_0070:  ldloc.s    CS$4$0001
        IL_0072:  brtrue.s   IL_0059
        IL_0074:  leave.s    IL_008a
      }  // end .try
      finally
      {
        IL_0076:  ldloc.s    CS$5$0002
        IL_0078:  ldnull
        IL_0079:  ceq
        IL_007b:  stloc.s    CS$4$0001
        IL_007d:  ldloc.s    CS$4$0001
        IL_007f:  brtrue.s   IL_0089
        IL_0081:  ldloc.s    CS$5$0002
        IL_0083:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0088:  nop
        IL_0089:  endfinally
      }  // end handler
      IL_008a:  nop
      IL_008b:  call       string [mscorlib]System.Console::ReadLine()
      IL_0090:  pop
      IL_0091:  ret
    } // end of method Program2::Main
