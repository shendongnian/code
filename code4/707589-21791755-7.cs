  // public Test(string s)
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    // Code size       36 (0x24)
    .maxstack  8
    // bool isNull = s == null;
    IL_0000:  ldarg.1
    IL_0001:  ldnull
    IL_0002:  ceq
    // bool isNotNull = isNull == false;
    IL_0004:  ldc.i4.0
    IL_0005:  ceq
    // __ContractsRuntime.Requires(isNotNull, null, null);
    IL_0007:  ldnull
    IL_0008:  ldnull
    IL_0009:  call       void System.Diagnostics.Contracts.__ContractsRuntime::Requires(bool, string, string)
    IL_000f:  ldarg.0
    // int temp = int.Parse(s);
    IL_0010:  ldarg.1
    IL_0011:  call       int32 [mscorlib]System.Int32::Parse(string)
    // : this(temp)
    IL_0016:  call       instance void ContractConstructorTest.Test::.ctor(int32)
    // return;
    IL_001e:  br         IL_0023
    IL_0023:  ret
  } // end of method Test::.ctor
