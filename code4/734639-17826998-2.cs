    .method private hidebysig instance int32 
            SeniorVersion() cil managed
    {
      // Code size       48 (0x30)
      .maxstack  2
      .locals init ([0] valuetype [mscorlib]System.DateTime dt1,
               [1] valuetype [mscorlib]System.DateTime dt2,
               [2] valuetype [mscorlib]System.TimeSpan ts,
               [3] int32 daysDiff,
               [4] valuetype [mscorlib]System.DateTime CS$0$0000)
      IL_0000:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
      IL_0005:  stloc.0
      IL_0006:  call       valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
      IL_000b:  stloc.s    CS$0$0000
      IL_000d:  ldloca.s   CS$0$0000
      IL_000f:  ldc.r8     -10.
      IL_0018:  call       instance valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::AddDays(float64)
      IL_001d:  stloc.1
      IL_001e:  ldloc.1
      IL_001f:  ldloc.0
      IL_0020:  call       valuetype [mscorlib]System.TimeSpan [mscorlib]System.DateTime::op_Subtraction(valuetype [mscorlib]System.DateTime,
                                                                                                         valuetype [mscorlib]System.DateTime)
      IL_0025:  stloc.2
      IL_0026:  ldloca.s   ts
      IL_0028:  call       instance int32 [mscorlib]System.TimeSpan::get_Days()
      IL_002d:  stloc.3
      IL_002e:  ldloc.3
      IL_002f:  ret
    } // end of method Program::SeniorVersion
